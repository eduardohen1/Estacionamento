using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estancionamento
{
    class Seguranca
    {
        private string ssSenhaDireta = "EH@07081983";
        private string ssDataPadrao = "07/08/1983";
        private int iiValorSeguranca = 123;
        private int iiSomaSeguranca = 11;

        public int iValorSeguranca { get { return iiValorSeguranca; } }
        public int iSomaSeguranca { get { return iiSomaSeguranca; } }

        /// <summary>
        /// Função para criptografar uma string passada por parâmetro
        /// </summary>
        /// <param name="sTexto">String a ser criptografado</param>
        /// <returns>Retorna texto criptografado</returns>
        public string sCriptografarString(string sTexto)
        {
            return criptografar(sTexto);
        }

        /// <summary>
        /// Função para descriptografar uma string passada por parâmetro
        /// </summary>
        /// <param name="sTexto">String a ser descriptografado</param>
        /// <returns>Retorna texto descriptografado</returns>
        public string sDescriptografarString(string sTexto)
        {
            return descriptografar(sTexto);
        }

        public string sSenhaDireta
        {
            get { return ssSenhaDireta; }
        }

        /*
        0 - E
        1 - D
        2 - 6 
        3 - A
        4 - R
        5 - 0 (zero)
        6 - H
        7 - N
        8 - 3
        9 - M
        */        
        private string criptografar(string sTexto)
        {
            string sResposta = "";
            int iInd = 0;
            if (sTexto.Length > 0)
            {
                while (iInd < sTexto.Length)
                {
                    switch (sTexto.Substring(iInd, 1))
                    {
                        case "0":
                            sResposta = sResposta + "E";
                            break;
                        case "1":
                            sResposta = sResposta + "D";
                            break;
                        case "2":
                            sResposta = sResposta + "6";
                            break;
                        case "3":
                            sResposta = sResposta + "A";
                            break;
                        case "4":
                            sResposta = sResposta + "R";
                            break;
                        case "5":
                            sResposta = sResposta + "0";
                            break;
                        case "6":
                            sResposta = sResposta + "H";
                            break;
                        case "7":
                            sResposta = sResposta + "N";
                            break;
                        case "8":
                            sResposta = sResposta + "3";
                            break;
                        case "9":
                            sResposta = sResposta + "M";
                            break;
                        case "E":
                            sResposta = sResposta + "T";
                            break;
                        case "A":
                            sResposta = sResposta + "7";
                            break;
                        case "N":
                            sResposta = sResposta + "9";
                            break;
                    }
                    iInd++;
                }//while
            }
            if (sResposta.Length == 0) sResposta = sTexto;
            return sResposta;
        }

        private string descriptografar(string sTexto)
        {
            string sResposta = "";
            int iInd = 0;
            if (sTexto.Length > 0)
            {
                while (iInd < sTexto.Length)
                {
                    switch (sTexto.Substring(iInd, 1))
                    {
                        case "E":
                            sResposta = sResposta + "0";
                            break;
                        case "D":
                            sResposta = sResposta + "1";
                            break;
                        case "6":
                            sResposta = sResposta + "2";
                            break;
                        case "A":
                            sResposta = sResposta + "3";
                            break;
                        case "R":
                            sResposta = sResposta + "4";
                            break;
                        case "0":
                            sResposta = sResposta + "5";
                            break;
                        case "H":
                            sResposta = sResposta + "6";
                            break;
                        case "N":
                            sResposta = sResposta + "7";
                            break;
                        case "3":
                            sResposta = sResposta + "8";
                            break;
                        case "M":
                            sResposta = sResposta + "9";
                            break;
                        case "T":
                            sResposta = sResposta + "E";
                            break;
                        case "7":
                            sResposta = sResposta + "A";
                            break;
                        case "9":
                            sResposta = sResposta + "N";
                            break;
                    }
                    iInd++;
                }//while
            }
            return sResposta;
        }


        private string retirarColocarMascara(string sLicenca, byte bTipo)
        {
            string sResposta = "";
            int iTipoLicenca = int.Parse(sLicenca.Substring(0, 1));
            switch (iTipoLicenca)
            {
                case 1:
                    //1NNNSSSSNNNNSSSSNNNN
                    if(bTipo == 0)
                        sResposta = sLicenca.Substring(0,4) + descriptografar(sLicenca.Substring(4,4)) + sLicenca.Substring(8,4) + descriptografar(sLicenca.Substring(12,4)) + sLicenca.Substring(16,4);
                    else
                        sResposta = sLicenca.Substring(0,4) + criptografar(sLicenca.Substring(4,4)) + sLicenca.Substring(8,4) + criptografar(sLicenca.Substring(12,4)) + sLicenca.Substring(16,4);
                    break;
                case 2:
                    //2SSSNNNNSSSSNNNNSSSS
                    if(bTipo == 0)
                        sResposta = iTipoLicenca.ToString() + descriptografar(sLicenca.Substring(1,3)) + sLicenca.Substring(4,4) + descriptografar(sLicenca.Substring(8,4)) + sLicenca.Substring(12,4) + descriptografar(sLicenca.Substring(16,4));
                    else
                        sResposta = iTipoLicenca.ToString() + criptografar(sLicenca.Substring(1,3)) + sLicenca.Substring(4,4) + criptografar(sLicenca.Substring(8,4)) + sLicenca.Substring(12,4) + criptografar(sLicenca.Substring(16,4));
                    break;
                case 3:
                    //3SNSSSNNSSSNNSNSNNSS
                    if(bTipo == 0)
                        sResposta = iTipoLicenca.ToString() + descriptografar(sLicenca.Substring(1,1)) + sLicenca.Substring(2,1) + descriptografar(sLicenca.Substring(3,5)) + sLicenca.Substring(6,2) + descriptografar(sLicenca.Substring(8,3)) + sLicenca.Substring(11,2) + descriptografar(sLicenca.Substring(13,1)) + sLicenca.Substring(14,1) + descriptografar(sLicenca.Substring(15,1)) + sLicenca.Substring(16,2) + descriptografar(sLicenca.Substring(18,2));
                    else
                        sResposta = iTipoLicenca.ToString() + criptografar(sLicenca.Substring(1, 1)) + sLicenca.Substring(2, 1) + criptografar(sLicenca.Substring(3, 5)) + sLicenca.Substring(6, 2) + criptografar(sLicenca.Substring(8, 3)) + sLicenca.Substring(11, 2) + criptografar(sLicenca.Substring(13, 1)) + sLicenca.Substring(14, 1) + criptografar(sLicenca.Substring(15, 1)) + sLicenca.Substring(16, 2) + criptografar(sLicenca.Substring(18, 2));
                    break;
                case 4:
                    //4SSSSSSSNNSSNNSSSSNN
                    if(bTipo ==0)
                        sResposta = iTipoLicenca.ToString() + descriptografar(sLicenca.Substring(1,7)) + sLicenca.Substring(8,2) + descriptografar(sLicenca.Substring(10,2)) + sLicenca.Substring(12,2) + descriptografar(sLicenca.Substring(14,4)) + sLicenca.Substring(18,2);
                    else
                        sResposta = iTipoLicenca.ToString() + criptografar(sLicenca.Substring(1, 7)) + sLicenca.Substring(8, 2) + criptografar(sLicenca.Substring(10, 2)) + sLicenca.Substring(12, 2) + criptografar(sLicenca.Substring(14, 4)) + sLicenca.Substring(18, 2);
                    break;
                case 5:
                    //5NNSSNSNNSSSSSNNNNNN
                    if(bTipo ==0)
                        sResposta = iTipoLicenca.ToString() + sLicenca.Substring(1,2) + descriptografar(sLicenca.Substring(3,2)) + sLicenca.Substring(5,1) + descriptografar(sLicenca.Substring(6,1)) + sLicenca.Substring(7,2) + descriptografar(sLicenca.Substring(9,5)) + sLicenca.Substring(14,6);
                    else
                        sResposta = iTipoLicenca.ToString() + sLicenca.Substring(1, 2) + criptografar(sLicenca.Substring(3, 2)) + sLicenca.Substring(5, 1) + criptografar(sLicenca.Substring(6, 1)) + sLicenca.Substring(7, 2) + criptografar(sLicenca.Substring(9, 5)) + sLicenca.Substring(14, 6);
                    break;
            }
            return sResposta;
        }

        /// <summary>
        /// Função para verificar a data de expiração do sistema
        /// </summary>
        /// <param name="sLicenca">Licença do cliente</param>
        /// <returns>Retorna verdadeiro ou falso</returns>
        public bool verificarDataExpiracao(string sLicenca)
        {
            bool bResposta = false;            
            sLicenca = retirarColocarMascara(sLicenca, 0);
            
            int iTipoLicenca = int.Parse(sLicenca.Substring(0, 1));
            int iDiasExpiracao = 0;

            switch (iTipoLicenca)
            {
                case 1:
                    iDiasExpiracao = int.Parse(sLicenca.Substring(1, 5));
                    break;
                case 2:
                    iDiasExpiracao = int.Parse(sLicenca.Substring(11, 5));
                    break;
                case 3:
                    iDiasExpiracao = int.Parse(sLicenca.Substring(7, 5));
                    break;
                case 4:
                    iDiasExpiracao = int.Parse(sLicenca.Substring(12, 5));
                    break;
                case 5:
                    iDiasExpiracao = int.Parse(sLicenca.Substring(5, 5));
                    break;
            }
            //verificar data de expiração:
            DateTime dtExpiracao = DateTime.Parse(ssDataPadrao).AddDays(iDiasExpiracao);

            if (DateTime.Now <= dtExpiracao)
                bResposta = true;
            else
                bResposta = false;

            return bResposta;  
        }

        private int verificarQteAcessos(string sLicenca)
        {
            int iResposta = 0;
            sLicenca = retirarColocarMascara(sLicenca, 0);
            int iTipoLicenca = int.Parse(sLicenca.Substring(0, 1));            

            switch (iTipoLicenca)
            {
                case 1:
                    iResposta = int.Parse(sLicenca.Substring(16, 4));
                    break;
                case 2:
                    iResposta = int.Parse(sLicenca.Substring(16, 4));
                    break;
                case 3:
                    iResposta = int.Parse(sLicenca.Substring(16, 4));
                    break;
                case 4:
                    iResposta = int.Parse(sLicenca.Substring(1, 4));
                    break;
                case 5:
                    iResposta = int.Parse(sLicenca.Substring(13, 4));
                    break;
            }            
            return iResposta;
        }

        /// <summary>
        /// Função para verificar a qte de acesso que um cliente tem após a expiração do prazo de licença
        /// </summary>
        /// <param name="sLicenca">Licença do cliente</param>
        /// <param name="iQteAcessos">Qte de acessos que o cliente ainda tem</param>
        /// <param name="bTipo">0 pela internet, 1 por comparação</param>
        /// <returns></returns>
        public bool verificarQteAcessosCliente(string sLicenca, int iQteAcessos, byte bTipo, string sIP)
        {
            bool bResposta = false;
            int iCodCliente = getCodigoCliente(sLicenca);
            int iQteAcessosBD = 1000;

            if (bTipo == 0)
            {
                //verificar em bd se os acessos estão dentro:
            }
            else            
                iQteAcessosBD = verificarQteAcessos(sLicenca);
            
            //comparação
            if (iQteAcessos <= iQteAcessosBD)
                bResposta = true;

            return bResposta;
        }

        /// <summary>
        /// Função para retornar o código do cliente, mediante a licença
        /// </summary>
        /// <param name="sLicenca">Licença do cliente</param>
        /// <returns>Retorna o código do cliente</returns>
        public int getCodigoCliente(string sLicenca)
        {
            int iResposta = 0;
            sLicenca = retirarColocarMascara(sLicenca,0);
            
            int iTipoLicenca = int.Parse(sLicenca.Substring(0, 1));
            int iCodigoCliente = 0;
            switch (iTipoLicenca)
            {
                case 1:
                    iCodigoCliente = int.Parse(sLicenca.Substring(9, 4));
                    break;
                case 2:
                    iCodigoCliente = int.Parse(sLicenca.Substring(4, 4));
                    break;
                case 3:
                    iCodigoCliente = int.Parse(sLicenca.Substring(12, 4));
                    break;
                case 4:
                    iCodigoCliente = int.Parse(sLicenca.Substring(8, 4));
                    break;
                case 5:
                    iCodigoCliente = int.Parse(sLicenca.Substring(1, 4));
                    break;            
            }

            return iCodigoCliente;
        }

        /// <summary>
        /// Função para pesquisar o código do sistema apartir da licença
        /// </summary>
        /// <param name="sLicenca">Licença do software</param>
        /// <returns>Retorna o código do sistema</returns>
        public int getCodigoSistema(string sLicenca)
        {
            int iCodigoSistema = 0;
            int iTipoLicenca = 0;
            sLicenca = retirarColocarMascara(sLicenca, 0);
            iTipoLicenca = int.Parse(sLicenca.Substring(0, 1));

            switch (iTipoLicenca)
            {
                case 1:
                    iCodigoSistema = int.Parse(sLicenca.Substring(13, 3));
                    break;
                case 2:
                    iCodigoSistema = int.Parse(sLicenca.Substring(8, 3));
                    break;
                case 3:
                    iCodigoSistema = int.Parse(sLicenca.Substring(1, 3));
                    break;
                case 4:
                    iCodigoSistema = int.Parse(sLicenca.Substring(17, 3));
                    break;
                case 5:
                    iCodigoSistema = int.Parse(sLicenca.Substring(17, 3));
                    break;
            }

            return iCodigoSistema;
        }

        /// <summary>
        /// Função para ativar ou não um computador
        /// </summary>
        /// <param name="sLicenca">Licença do cliente</param>
        /// <param name="sNumHD">Num HD do cliente</param>
        /// <param name="sNomeMaquina">Nome da máquina que está pedindo ativação</param>
        /// <param name="dtDataAtual">Data de ativação</param>
        /// <returns>Ativado ou não</returns>
        public bool ativarComputador(string sLicenca, string sNumHD, string sNomeMaquina, DateTime dtDataAtual, out string sAtivacao)
        {
            bool bResposta = true;
            string sAtiva = "A";
            int iCodCliente = getCodigoCliente(sLicenca);
            sAtivacao = "";

            //já ultrapassou a qte de ativações por licença, caso sim, verificar se a máquina está pedindo nova ativação

            //verificar em BD se existe alguma ativação para esta máquina

            sAtivacao = criptografar(iCodCliente.ToString("D4")) + "." + criptografar(sNumHD) + "." + criptografar(sAtiva);
            return bResposta;
        }

        private string buscaLicencaCliente(int iCodCliente)
        {
            string sResposta = "4EMMMEEA00ED11A0EE01";
            return sResposta;
        }

        /// <summary>
        /// Função para gerar contra-chave para ativação
        /// </summary>
        /// <param name="sChave">Chave gerada na máquina</param>
        /// <returns>Retorna contra-chave com a liberação</returns>
        public string gerarContraChaveAtivacao(string sChave)
        {
            string sResposta = "";
            string sAtivacao = "";
            string[] cChave = sChave.Split('.');
            int iCodCliente = int.Parse(descriptografar(cChave[0]));
            int iCodSistema = int.Parse(descriptografar(cChave[2]));
            if (ativarComputador(buscaLicencaCliente(iCodCliente), cChave[1], "", DateTime.Now, out sAtivacao))
            {
                iCodCliente = iCodCliente + iiValorSeguranca;
                sResposta = criptografar(iCodCliente.ToString("D5"));
            }
            return sResposta;
        }

        /// <summary>
        /// Função para validar chave de ativação dada via telefone
        /// </summary>
        /// <param name="sChave">Chave de ativação </param>
        /// <param name="sLicenca">Licença do cliente</param>
        /// <returns>Retorna verdadeiro ou falso</returns>
        public bool validarChaveAtivacao(string sChave, string sLicenca)
        {
            bool bResposta = false;
            int iCodCliente = getCodigoCliente(sLicenca);
            int iChave = int.Parse(descriptografar(sChave));

            if (iCodCliente == (iChave - iiValorSeguranca))
                bResposta = true;

            return bResposta;
        }

        private string retirarPonto(string sTexto)
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

        /// <summary>
        /// Função para gerar chave de tela
        /// </summary>
        /// <param name="dtAgora">Data do micro</param>
        /// <param name="sLicenca">Licença do cliente</param>
        /// <returns>Retorna a chave gerada</returns>
        public string gerarChaveTela(DateTime dtAgora, string sLicenca)
        {
            string sResposta = "";
            //Chave Minuto[c].FatorDia(*).CodCliente[c]
            //(*) FatorDia = e o dia atual - 07/08/1983
            //[c] criptografado
            DateTime dtAnt = DateTime.Parse(ssDataPadrao);
            TimeSpan tsDiferenca = dtAgora - dtAnt;
            int iFator = tsDiferenca.Days;
            sResposta = criptografar(dtAgora.Minute.ToString("D2")) + "." + iFator.ToString("D5") + "." + criptografar(getCodigoCliente(sLicenca).ToString("D4"));
            return sResposta;
        }

        /// <summary>
        /// Função para gerar contra-cahve de acesso a telas
        /// </summary>
        /// <param name="sChave"></param>
        /// <returns></returns>
        public string gerarContraChaveTela(string sChave)
        {
            string sResposta = "";
            sChave = retirarPonto(sChave);
            int iMinuto = int.Parse(descriptografar(sChave.Substring(0, 2)));            
            int iFator = int.Parse(sChave.Substring(2, 5));
            int iCodCliente = int.Parse(sChave.Substring(7, 4));
            DateTime dtAtual = DateTime.Parse(ssDataPadrao).AddDays(iFator);

            if (dtAtual.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
            {
                //confirmar se cod cliente bate no banco do cliente
                //gravar no banco a geração de chave
                sResposta = iMinuto.ToString("D2") + "." + iFator.ToString("D5") + "." + criptografar((iMinuto + 1).ToString("D2")) + "@EH";
            }
            else
            {
                sResposta = iMinuto.ToString("D2") + "." + criptografar(iFator.ToString("D5")) + "." + criptografar(iMinuto.ToString("D2")) + "@EH";
            }
            return sResposta;
        }

        /// <summary>
        /// Função para validar chave gerada
        /// </summary>
        /// <param name="sChave">Chave inicial</param>
        /// <param name="sContraChave">Contra chave</param>
        /// <returns>Retorna verdadeiro ou falso</returns>
        public bool validarChave(string sChave, string sContraChave)
        {
            bool bResposta = false;
            sChave = retirarPonto(sChave);
            sContraChave = retirarPonto(sContraChave);

            int iMinutoOrigem = int.Parse(descriptografar(sChave.Substring(0, 2)));
            int iMinutoOrigem2 = int.Parse(sContraChave.Substring(0, 2));
            int iMinutoValido = int.Parse(descriptografar(sContraChave.Substring(7, 2)));

            if ((iMinutoOrigem == (iMinutoValido - 1)) && (iMinutoOrigem == iMinutoOrigem2))
            {
                bResposta = true;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar dados da licença
        /// </summary>
        /// <param name="sLicenca">Licença do sistema</param>
        /// <returns>Objeto licenciamento</returns>
        public licenciamento retornaDadosLicenca(string sLicenca)
        {
            licenciamento obLicenciamento = new licenciamento();
            int iTipoLicenca = 0;

            sLicenca = retirarPonto(sLicenca);
            obLicenciamento.iCodCliente = getCodigoCliente(sLicenca);
            obLicenciamento.iCodSistema = getCodigoSistema(sLicenca);
            obLicenciamento.iQteAcessos = verificarQteAcessos(sLicenca);

            sLicenca = retirarColocarMascara(sLicenca, 0);
            iTipoLicenca = int.Parse(sLicenca.Substring(0, 1));

            switch (iTipoLicenca)
            {
                case 1:
                    obLicenciamento.iDataExpiracao = int.Parse(sLicenca.Substring(1, 5));
                    obLicenciamento.iQteLicencas = int.Parse(sLicenca.Substring(6, 3));
                    break;
                case 2:
                    obLicenciamento.iDataExpiracao = int.Parse(sLicenca.Substring(11, 5));
                    obLicenciamento.iQteLicencas = int.Parse(sLicenca.Substring(1, 3));
                    break;
                case 3:
                    obLicenciamento.iDataExpiracao = int.Parse(sLicenca.Substring(7, 5));
                    obLicenciamento.iQteLicencas = int.Parse(sLicenca.Substring(4, 3));
                    break;
                case 4:
                    obLicenciamento.iDataExpiracao = int.Parse(sLicenca.Substring(12, 5));
                    obLicenciamento.iQteLicencas = int.Parse(sLicenca.Substring(5, 3));
                    break;
                case 5:
                    obLicenciamento.iDataExpiracao = int.Parse(sLicenca.Substring(5, 5));
                    obLicenciamento.iQteLicencas = int.Parse(sLicenca.Substring(10, 3));
                    break;
            }
            return obLicenciamento;
        }

        /// <summary>
        /// Validar licença digitada
        /// </summary>
        /// <param name="sChave">Chave gerada em tela contendo o código do cliente para comparação</param>
        /// <param name="iCodigoCliente">Código do cliente para comparação</param>
        /// <returns>Retorna string com validação</returns>
        public string validarLicenca(string sChave, int iCodigoCliente)
        {
            string sResposta = "ERR@" + sCriptografarString(DateTime.Now.Minute.ToString("D2"));            
            string[] cChave = sChave.Split('@');
            cChave[0] = sDescriptografarString(cChave[0]);
            cChave[1] = sDescriptografarString(cChave[1]);

            if (iCodigoCliente == int.Parse(cChave[0]))
            {
                int iMinuto = int.Parse(cChave[1]);
                iMinuto = iMinuto + iSomaSeguranca;
                sResposta = sCriptografarString(iValorSeguranca.ToString("D4")) + "@" + sCriptografarString(iMinuto.ToString("D2"));
            }
            return sResposta;
        }

    }
}
