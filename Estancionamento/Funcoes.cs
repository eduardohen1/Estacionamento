using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using System.Security;
using System.Net;

namespace Estancionamento
{
    public class Funcoes
    {

        const string senha = "E!09#x*&aTE$";
        
        /// <summary>
        /// Função para ler registro, caso não exista, cria-se
        /// </summary>
        /// <param name="sKeyname">Chave a ser pesquisada</param>
        public void CheckRegistryKey(string sKeyname) {   
            RegistryKey oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + sKeyname, true);   
            if(oRegistryKey==null)   {     
                oRegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", true);     
                oRegistryKey.CreateSubKey(sKeyname);   
            } 
        }

        /// <summary>
        /// Verifica o valor de uma chave, caso não encontrada, pegar o valor padrão
        /// </summary>
        /// <param name="sKeyname">Chave a ser pesquisada</param>
        /// <param name="sValueName">Nome do valor</param>
        /// <param name="sDefaultValue">Valor padrão</param>
        /// <returns>Retorna a chave</returns>
        public string GetStringValue(string sKeyname, string sValueName, string sDefaultValue) {   
            RegistryKey oRegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + sKeyname, true);   
            if(oRegistryKey==null)   {     
                oRegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", true);     
                oRegistryKey.CreateSubKey(sKeyname);   
            }     
            if(oRegistryKey.GetValue(sValueName)==null){     
                oRegistryKey.SetValue(sValueName, sDefaultValue);     
                return sDefaultValue;   
            }  else     
                return (string)oRegistryKey.GetValue(sValueName); 
        }

        /// <summary>
        /// Gravar o valor de uma chave
        /// </summary>
        /// <param name="sKeyname">Chave a ser pesquisada</param>
        /// <param name="sValueName">Nome do valor</param>
        /// <param name="sValue">Valor a ser gravado</param>
        public void SetStringValue(string sKeyname, string sValueName,   string sValue) {   
            RegistryKey oRegistryKey =     Registry.LocalMachine.OpenSubKey("SOFTWARE\\" + sKeyname, true);   
            if(oRegistryKey==null)   {     
                oRegistryKey =       Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", true);     
                oRegistryKey.CreateSubKey(sKeyname);   
            }     
            oRegistryKey.SetValue(sValueName, sValue); 
        }

        /// <summary>
        /// Função para retornar o right de uma determinada string
        /// </summary>
        /// <param name="sValue">Texto para extração</param>
        /// <param name="iMaxLenght">Quantidade de caracteres</param>
        /// <returns>Retorna string</returns>
        public string returRight(string sValue, int iMaxLenght)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                sValue = string.Empty;
            }
            else if (sValue.Length > iMaxLenght)
            {
                sValue = sValue.Substring(sValue.Length - iMaxLenght, iMaxLenght);
            }
            return sValue;
        }

        /// <summary>
        /// Gerar senha de acesso para contra-chave
        /// </summary>
        /// <returns>Senha numérica para contra-chave</returns>
        public string geraSenhaAcesso(FrmPrincipal vFrmPrincipal)
        {
            Conexao con = new Conexao();
            Drive vDrive = Drive.GetDrive("C");
            DateTime dt = DateTime.Now;            
            string sHora;
            string sData;
            long lValor;
            long lSerial;
            string sResposta="";
            string[] vCodCliente;

            sHora = string.Format("{0:HH:mm:ss}", dt);
            sData = String.Format("{0:ddMMyyyy}",dt);
            lSerial = vDrive.SerialNumber;
            lValor = (int.Parse(sHora.Substring(0, 2)) + int.Parse(sHora.Substring(3, 2)) + int.Parse(sHora.Substring(6, 2))) + int.Parse(sData);//lSerial;// / (int.Parse(sHora.Substring(0, 2)) + int.Parse(sHora.Substring(3, 2)) + int.Parse(sHora.Substring(6, 2)));

            if (con.buscarDadosConexao(vFrmPrincipal.vvEnderecoConfig))
            {
                vCodCliente = con.vvChaveAcesso.Split('@');
                sResposta = sHora.Substring(0, 2) + "ES" + sHora.Substring(3, 2) + "T" + sHora.Substring(6, 2) + "." + vCodCliente[0] + "." + lValor.ToString();
                sResposta = Criptografar(sResposta);            
            }
            return sResposta;
        }

        public bool validarSenhaAcesso(string vSenha, string vSenhaGerada)
        {            
            //int iSenhaEH;
            string sSenhaEH;
            //int iFator;
            //long lResposta;
            bool bResposta;
            DateTime dt = DateTime.Now;
            string sHora;
            string sChave01;
            string[] vvChave01;
            string[] vvChave02;

            if (!vSenha.Substring(0, 3).Equals("EST"))
            {
                vSenha = Descriptografar(vSenha);
                vSenhaGerada = Descriptografar(vSenhaGerada);

                vvChave01 = vSenha.Split('.');
                vvChave02 = vSenhaGerada.Split('.');
                sChave01 = vvChave01[0].Substring(0, 1) + vvChave01[0].Substring(3, 1);
                if (sChave01.Equals("OK") && vvChave01[1] == vvChave02[2] && vvChave01[2] == vvChave02[1])
                    bResposta = true;
                else
                    bResposta = false;
            }
            else
            {
                sHora = string.Format("{0:dd/MM/yyyy HH:mm:ss}", dt);
                int iDia = int.Parse(sHora.Substring(0, 2));
                int iMes = int.Parse(sHora.Substring(3, 2));
                int vMinuto = int.Parse(sHora.Substring(15, 1));

                sSenhaEH = "EST" + String.Format("{0:D3}", (iDia + iMes)) + vMinuto.ToString();

                if (vSenha.Equals(sSenhaEH))
                    bResposta = true;
                else
                    bResposta = false;

            }
            /*
            if (eNumeral(vSenha))
            {                
                iSenhaEH = int.Parse((long.Parse(vSenhaGerada) / 27).ToString());

                if (int.Parse(iSenhaEH.ToString().Substring(2, 1)) <= 1)                
                    iFator = 6;
                else
                    iFator = int.Parse(iSenhaEH.ToString().Substring(2, 1));

                lResposta = iSenhaEH * iFator;

                if (vSenha.Equals(lResposta.ToString()))
                    bResposta = true;
                else
                    bResposta = false;

            }
            else
            {
                sHora = string.Format("{0:dd/MM/yyyy HH:mm:ss}", dt);
                int iDia = int.Parse(sHora.Substring(0, 2));
                int iMes = int.Parse(sHora.Substring(3, 2));
                int vMinuto = int.Parse(sHora.Substring(15, 1));

                sSenhaEH = "EST" + String.Format("{0:D3}", (iDia + iMes)) + vMinuto.ToString();

                if (vSenha.Equals(sSenhaEH))
                    bResposta = true;
                else
                    bResposta = false;

            }
             * */
            return bResposta;
        }

        public bool eNumeral(string s)
        {
            float fSaida;
            try
            {
                fSaida = float.Parse(s);
                return true;
            }catch(Exception ex){
                return false;
            }
        }

        public string retirarPonto(string sTexto)
        {
            string sResposta = "";

            if (sTexto.Length > 0)
            {
                foreach (char cTexto in sTexto)
                {
                    if (cTexto != '.')
                        sResposta = sResposta + cTexto;
                }
            }
            else
                sResposta = sTexto;
            return sResposta;
        }

        /*
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }*/

        /// <summary>
        /// Rotina para criptografar valores em MD5
        /// </summary>
        /// <param name="Message">Texto para criptografia</param>
        /// <returns>Texto criptografado</returns>
        public string Criptografar(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            System.Security.Cryptography.MD5CryptoServiceProvider HashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));
            System.Security.Cryptography.TripleDESCryptoServiceProvider TDESAlgorihm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            TDESAlgorihm.Key = TDESKey;
            TDESAlgorihm.Mode = System.Security.Cryptography.CipherMode.ECB;
            TDESAlgorihm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            byte[] DAtaToEncrypt = UTF8.GetBytes(Message);
            try
            {
                System.Security.Cryptography.ICryptoTransform Encryptor = TDESAlgorihm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DAtaToEncrypt, 0, DAtaToEncrypt.Length);
            }
            finally
            {
                TDESAlgorihm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }

        /// <summary>
        /// Função estática para descriptografar em MD5
        /// </summary>
        /// <param name="Message">Texto criptografado</param>
        /// <returns>Texto sem criptografia</returns>
        public string Descriptografar(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            System.Security.Cryptography.MD5CryptoServiceProvider HashProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));
            System.Security.Cryptography.TripleDESCryptoServiceProvider TDESAlgorithm = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = System.Security.Cryptography.CipherMode.ECB;
            TDESAlgorithm.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                System.Security.Cryptography.ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }

        /// <summary>
        /// Rotina para criar criptografia apartir de números para código de cliente
        /// </summary>
        /// <param name="sTexto">Texto numérico (Código do cliente) para criptografia</param>
        /// <returns>Texto já criptografado</returns>
        public string criptografia(string sTexto)
        {
            string sResposta = "";
            int iX = 0;
            for (iX = 0; iX < sTexto.Length; iX++)
            {
                switch (int.Parse(sTexto.Substring(iX, 1)))
                {
                    case 0:
                        sResposta = sResposta + "F";
                        break;
                    case 1:
                        sResposta = sResposta + "A";
                        break;
                    case 2:
                        sResposta = sResposta + "9";
                        break;
                    case 3:
                        sResposta = sResposta + "E";
                        break;
                    case 4:
                        sResposta = sResposta + "6";
                        break;
                    case 5:
                        sResposta = sResposta + "L";
                        break;
                    case 6:
                        sResposta = sResposta + "3";
                        break;
                    case 7:
                        sResposta = sResposta + "X";
                        break;
                    case 8:
                        sResposta = sResposta + "Q";
                        break;
                    case 9:
                        sResposta = sResposta + "U";
                        break;
                }
            }//for
            return sResposta;
        }
        /// <summary>
        /// Rotina para quebrar a criptografia do sistemas
        /// </summary>
        /// <param name="sTexto">Registro criptografado</param>
        /// <returns>Saída de registro limpo</returns>
        public string descriptografar(string sTexto)
        {
            string sResposta = "";
            int iX = 0;
            for (iX = 0; iX < sTexto.Length; iX++)
            {
                switch (sTexto.Substring(iX, 1))
                {
                    case "F":
                        sResposta = sResposta + "0";
                        break;
                    case "A":
                        sResposta = sResposta + "1";
                        break;
                    case "9":
                        sResposta = sResposta + "2";
                        break;
                    case "E":
                        sResposta = sResposta + "3";
                        break;
                    case "6":
                        sResposta = sResposta + "4";
                        break;
                    case "L":
                        sResposta = sResposta + "5";
                        break;
                    case "3":
                        sResposta = sResposta + "6";
                        break;
                    case "X":
                        sResposta = sResposta + "7";
                        break;
                    case "Q":
                        sResposta = sResposta + "8";
                        break;
                    case "U":
                        sResposta = sResposta + "9";
                        break;

                }//switch
            }//for

            return sResposta;
        }

        public bool conectadoInternet()
        {
            return IsConnectedToInternet();
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        /// <summary>
        /// verificar se está conectado à internet
        /// </summary>
        /// <returns>true se existir uma conexão</returns>
        /// <remarks>retornar true não quer dizer que o destino esteja alcançável, utilize
        /// IsReachable(url) para saber se o destino está alcançável</remarks>
        public static bool IsConnectedToInternet()
        {
            int Desc;
            bool ret = InternetGetConnectedState(out Desc, 0);
            if (ret)
                ret = IsReachable("http://www.google.com");
            return ret;
        }
        
        public static bool IsReachable(string _url)
        {
            System.Uri Url = new System.Uri(_url);
            System.Net.WebRequest webReq;
            System.Net.WebResponse resp;
            webReq = System.Net.WebRequest.Create(Url);
            try
            {
                resp = webReq.GetResponse();
                resp.Close();
                webReq = null;
                return true;
            }
            catch
            {
                webReq = null;
                return false;
            }
        }

        [DllImport("kernel32.dll")]
        private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, UInt32 VolumeNameSize, ref UInt32 VolumeSerialNumber, ref UInt32 MaximumComponentLength, ref UInt32 FileSystemFlags, StringBuilder FileSystemNameBuffer, UInt32 FileSystemNameSize);

        /// <summary>
        /// Função para buscar o num serial do HD
        /// </summary>
        /// <param name="strDriveLetter">Letra do driver</param>
        /// <returns>Retorna o num de serie do HD</returns>
        public string GetVolumeSerial(string strDriveLetter)
        {
            uint serNum = 0;
            uint maxCompLen = 0;
            StringBuilder VolLabel = new StringBuilder(256); // Label
            UInt32 VolFlags = new UInt32();
            StringBuilder FSName = new StringBuilder(256); // File System Name
            strDriveLetter += ":\\"; // fix up the passed-in drive letter for the API call
            long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);

            return Convert.ToString(serNum);
        }

        /// <summary>
        /// Função para retornar o IP da máquina
        /// </summary>
        /// <returns>Retorna o IP da máquina</returns>
        public string retornaIP()
        {
            try
            {
                string nome = Dns.GetHostName();
                IPAddress[] ip = Dns.GetHostAddresses(nome);
                return ip[1].ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Função para validar o CPF digitado em tela
        /// </summary>
        /// <param name="sCPF">CPF</param>
        /// <returns>Retorna se o CPF é válido ou não</returns>
        public bool validarCPF(string sCPF)
        {
            string valor = sCPF.Replace(".", ""); 
            valor = valor.Replace("-", ""); 
            if (valor.Length != 11) 
                return false; 
            bool igual = true; 
            for (int i = 1; i < 11 && igual; i++) 
                if (valor[i] != valor[0]) 
                    igual = false; 
            if (igual || valor == "12345678909") 
                return false; 
            int[] numeros = new int[11]; 
            for (int i = 0; i < 11; i++) 
                numeros[i] = int.Parse( valor[i].ToString()); 
            int soma = 0; 
            for (int i = 0; i < 9; i++) 
                soma += (10 - i) * numeros[i]; 
            int resultado = soma % 11; 
            if (resultado == 1 || resultado == 0) { 
                if (numeros[9] != 0) 
                    return false; 
            } else if (numeros[9] != 11 - resultado) 
                return false; 
            soma = 0; 
            for (int i = 0; i < 10; i++) 
                soma += (11 - i) * numeros[i];
            resultado = soma % 11; 
            if (resultado == 1 || resultado == 0) { 
                if (numeros[10] != 0) 
                    return false; 
            } else if (numeros[10] != 11 - resultado) 
                return false; 
            return true;
        }

        /// <summary>
        /// Função para validar o CNPJ digitado em tela
        /// </summary>
        /// <param name="sCNPJ">CNPJ digitado</param>
        /// <returns>Retorna se o CNPJ é válido ou não</returns>
        public bool validarCNPJ(string sCNPJ)
        {
            string CNPJ = sCNPJ.Replace(".", ""); 
            CNPJ = CNPJ.Replace("/", ""); 
            CNPJ = CNPJ.Replace("-", ""); 
            int[] digitos, soma, resultado; 
            int nrDig; 
            string ftmt; 
            bool[] CNPJOk; 
            ftmt = "6543298765432"; 
            digitos = new int[14]; 
            soma = new int[2]; 
            soma[0] = 0; 
            soma[1] = 0; 
            resultado = new int[2]; 
            resultado[0] = 0; 
            resultado[1] = 0; 
            CNPJOk = new bool[2]; 
            CNPJOk[0] = false; 
            CNPJOk[1] = false; 
            try { 
                for (nrDig = 0; nrDig < 14; nrDig++) { 
                    digitos[nrDig] = int.Parse( CNPJ.Substring(nrDig, 1)); 
                    if (nrDig <= 11) soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring( nrDig + 1, 1))); 
                    if (nrDig <= 12) soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring( nrDig, 1))); 
                } 
                for (nrDig = 0; nrDig < 2; nrDig++) { 
                    resultado[nrDig] = (soma[nrDig] % 11); 
                    if ((resultado[nrDig] == 0) || ( resultado[nrDig] == 1)) 
                        CNPJOk[nrDig] = ( digitos[12 + nrDig] == 0); 
                    else 
                        CNPJOk[nrDig] = ( digitos[12 + nrDig] == ( 11 - resultado[nrDig])); 
                } 
                return (CNPJOk[0] && CNPJOk[1]); 
            } catch { 
                return false; 
            }
        }

        /// <summary>
        /// Função para validar e-mail digitado
        /// </summary>
        /// <param name="sEmail">E-mail digitado</param>
        /// <returns>Retorna se e-mail é válido</returns>
        public bool validarEmail(string sEmail)
        {
            bool validEmail = false;
            int indexArr = sEmail.IndexOf('@');
            if (indexArr > 0)
            {
                int indexDot = sEmail.IndexOf('.', indexArr);
                if (indexDot - 1 > indexArr)
                {
                    if (indexDot + 1 < sEmail.Length)
                    {
                        string indexDot2 = sEmail.Substring(indexDot + 1, 1);
                        if (indexDot2 != ".")
                        {
                            validEmail = true;
                        }
                    }
                }
            }
            return validEmail;
        }

    }
}
