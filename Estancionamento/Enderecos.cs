using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Estancionamento
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
    public class Municipio
    {
        public int Codigo { get; set; }
        public string Nome_municipio { get; set; }
        public string UF { get; set; }
    }

    public class Localidade
    {
        public int Codigo { get; set; }
        public string Nome_localidade { get; set; }
        public int Cod_Municipio { get; set; }
    }

    public class Bairro
    {
        public int Codigo { get; set; }
        public string Nome_bairro { get; set; }
        public int Cod_localidade { get; set; }
    }

    public class Logradouro_tipo
    {
        public int Codigo { get; set; }
        public string Tipo { get; set; }
        public string Abreviacao { get; set; }
    }

    public class Logradouro
    {
        public int Codigo { get; set; }
        public string Nome_logradouro { get; set; }
        public int Tipo { get; set; }
        public string CEP { get; set; }
        public int Cod_bairro { get; set; }
    }

    class Enderecos
    {
        //comandos
        CamadaDados execComandos = new CamadaDados();
        
        //conexao 
        SqlConnection cnConexao;
        string sServidor;
        string sDataBase;
        string sUsuario;
        string sSenha;
        string sChaveAcesso;
        int iPortaAcesso;
        string sArquivoConexao;

        //Localidade
        int iCodLocalidade;
        string sNomeLocalidade;
        int iCodMunicipioLocalidade;

        //Municipio
        int iCodMunicipio;
        string sNomeMunicipio;
        string sUF;

        //Bairro
        int iCodBairro;
        string sNomeBairro;
        int iCodLocalidadeBairro;
        
        //Logradouro
        int iCodLogradouro;
        string sTipoLogradouro;
        string sNomeLogradouro;
        string sCEP;
        int iCodBairroLogradouro;

        //Localidade
        public int CodigoLocalidade
        {
            get { return iCodLocalidade; }
            set { iCodLocalidade = value; }            
        }
        public string NomeLocalidade
        {
            get { return sNomeLocalidade; }
            set { sNomeLocalidade = value; }
        }
        public int CodigoMunincipioLocalidade
        {
            get { return iCodMunicipioLocalidade; }
            set { iCodMunicipioLocalidade = value; }
        }

        //Municipio
        public int CodigoMunicipio
        {
            get { return iCodMunicipio; }
            set { iCodMunicipio = value; }
        }
        public string NomeMunicipio
        {
            get { return sNomeMunicipio; }
            set { sNomeMunicipio = value; }
        }
        public string UF
        {
            get { return sUF; }
            set { sUF = value; }
        }

        //bairro
        public int CodigoBairro
        {
            get { return iCodBairro; }
            set { iCodBairro = value; }
        }
        public string NomeBairro
        {
            get { return sNomeBairro; }
            set { sNomeBairro = value; }
        }
        public int CodigoLocalidadeBairro
        {
            get { return iCodLocalidadeBairro; }
            set { iCodLocalidadeBairro = value; }
        }

        //Logradouro
        public int CodigoLogradouro
        {
            get { return iCodLogradouro; }
            set { iCodLogradouro = value; }
        }

        public string TipoLogradouro
        {
            get { return sTipoLogradouro; }
            set { sTipoLogradouro = value; }
        }

        public string NomeLogradouro
        {
            get { return sNomeLogradouro; }
            set { sNomeLogradouro = value; }
        }
        public string CEP
        {
            get { return sCEP; }
            set { sCEP = value; }
        }
        public int CodigoBairroLogradouro
        {
            get { return iCodBairroLogradouro; }
            set { iCodBairroLogradouro = value; }
        }

        //Conexao
        public SqlConnection Conexao
        {
            set { cnConexao = value; }
        }

        public string NomeServidor
        {
            get { return sServidor; }
            set { sServidor = value; }
        }
        public string DataBase
        {
            get { return sDataBase; }
            set { sDataBase = value; }
        }
        public string UsuarioDataBase
        {
            get { return sUsuario; }
            set { sUsuario = value; }
        }
        public string SenhaDataBase
        {
            get { return sSenha; }
            set { sSenha = value; }
        }
        public string ArquivoConexao
        {
            get { return sArquivoConexao; }
            set { sArquivoConexao = value; }
        }

        //Metodos - Municipio
        /// <summary>
        /// Gravar municipios apartir das variáveis da classe
        /// </summary>
        /// <param name="cMunicipio">Objeto Municipio com suas propriedades</param>
        /// <param name="vTipo">Tipo 0 - Novo; Tipo 1 - Atualizar</param>
        /// <returns>Retorna TRUE ou FALSE conforme a execução do comando</returns>
        public bool gravarMunicipio(Municipio cMunicipio, byte vTipo)
        {
            bool bResposta = true;

            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    switch (vTipo)
                    {
                        case 0:
                            //novo
                            cMunicipio.Codigo = execComandos.ultimoCodigoMunicipio();
                            cMunicipio.Codigo = cMunicipio.Codigo + 1;
                            if (cMunicipio.Codigo != 0)
                            {
                                if (!execComandos.inserirMunicipio(cMunicipio.Codigo, cMunicipio.Nome_municipio, cMunicipio.UF)) bResposta = false;
                            }
                            else
                            {
                                bResposta = false;
                            }
                            break;
                        case 1:
                            //alterar
                            if (!execComandos.alterarMunicipio(cMunicipio.Codigo, cMunicipio.Nome_municipio, cMunicipio.UF)) bResposta = false;
                            break;
                    }

                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            else
                bResposta = false;
            return bResposta;
        }

        public Municipio pesquisarMunicipio(int vvCod)
        {
            Municipio cMunicipio = new Municipio();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cMunicipio = execComandos.pesquisaMunicipio(vvCod);
                    /*drLer = execComandos.pesquisaMunicipio(vvCod);
                    if (drLer.HasRows)
                    {
                        if (drLer.Read())
                        {
                            cMunicipio.Codigo = int.Parse(drLer["codigo"].ToString());
                            cMunicipio.Nome_municipio = drLer["Nome_municipio"].ToString();
                            cMunicipio.UF = drLer["UF"].ToString();
                        }

                    }*/
                    return cMunicipio;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;
        }

        public Municipio pesquisarMunicipio(string sMunicipio)
        {
            Municipio cMunicipio = new Municipio();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    return execComandos.pesquisaMunicipio(sMunicipio);
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;
        }

        public List<Municipio> pesquisarTodosMunicipio()
        {
            SqlDataReader drLer;
            execComandos.Conexao = cnConexao;
            drLer = null;
            List<Municipio> _Municipio = new List<Municipio>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    _Municipio = execComandos.pesquisaTodosMunicipio();
                    /*drLer = execComandos.pesquisaTodosMunicipio();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Municipio.Add(new Municipio(){
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                Nome_municipio = drLer["Nome_municipio"].ToString(),
                                UF = drLer["UF"].ToString()
                            });
                        }
                    }*/
                    execComandos.Desconectar();
                }
            }            
            return _Municipio;
        }

        public bool municipioExiste(string sMunicipio)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeMunicipio(sMunicipio);
                    execComandos.Desconectar();
                }
            }
            return bResposta;
        }

        public bool excluirMunicipio(int vvCod)
        {
            bool bResposta = true;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (!execComandos.excluirMunicipio(vvCod)) bResposta = false;
                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            return bResposta;
        }

        public bool seExisteMunicipio(string sNome_municipio)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeMunicipio(sNome_municipio);
                }
            }
            return bResposta;
        }

        //Metodos - Localidade
        public bool gravarLocalidade(Localidade cLocalidade, byte vTipo){
            bool bResposta = true;

            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    switch (vTipo)
                    {
                        case 0:
                            //novo
                            cLocalidade.Codigo = execComandos.ultimoCodigoLocalidade();
                            cLocalidade.Codigo++;
                            if (cLocalidade.Codigo != 0)
                            {
                                if (!execComandos.inserirLocalidade(cLocalidade.Codigo, cLocalidade.Nome_localidade, cLocalidade.Cod_Municipio)) bResposta = false;
                            }
                            else
                            {
                                bResposta = false;
                            }
                            break;
                        case 1:
                            //alterar
                            if (!execComandos.alterarLocalidade(cLocalidade.Codigo, cLocalidade.Nome_localidade, cLocalidade.Cod_Municipio)) bResposta = false;
                            break;
                    }

                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            return bResposta;
        }

        /// <summary>
        /// Funçao para pesquisar os dados de Localidade por código
        /// </summary>
        /// <param name="vvCod">Código da localidade para pesquisa</param>
        /// <returns>Retorna objeto Localidade</returns>
        public Localidade pesquisarLocalidade(int vvCod) {
            SqlDataReader drLer;
            Localidade cLocalidade = new Localidade();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaLocalidade(vvCod);
                    if (drLer.HasRows)
                    {
                        if (drLer.Read())
                        {
                            cLocalidade.Codigo = int.Parse(drLer["codigo"].ToString());
                            cLocalidade.Nome_localidade = drLer["Nome_localidade"].ToString();
                            cLocalidade.Cod_Municipio = int.Parse(drLer["Cod_Municipio"].ToString());
                        }

                    }
                    return cLocalidade;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;

        }

        /// <summary>
        /// Função para pesquisar uma determinada localidade
        /// </summary>
        /// <param name="sNomeLocalidade">Nome da localidade para pesquisa</param>
        /// <returns>Retorna objeto Localidade</returns>
        public Localidade pesquisarLocalidade(string sNomeLocalidade)
        {
            Localidade cLocalidade = new Localidade();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cLocalidade = execComandos.pesquisaLocalidade(sNomeLocalidade);
                    return cLocalidade;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;

        }

        /// <summary>
        /// Função para pesquisar as localidades de um município
        /// </summary>
        /// <param name="iCodigoMunicipio">Código do município</param>
        /// <returns>Retorna uma lista de localidades</returns>
        public List<Localidade> pesquisarLocalidade(int iCodigoMunicipio,byte bTipo = 0)
        {
            List<Localidade> lstLocalidade = new List<Localidade>();            
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstLocalidade = execComandos.pesquisaLocalidade(iCodigoMunicipio, bTipo);
                    return lstLocalidade;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;

        }

        public bool excluirLocalidade(int vvCod) {
            bool bResposta = true;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (!execComandos.excluirLocalidade(vvCod)) bResposta = false;
                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            return bResposta;
        }

        public List<Localidade> pesquisarTodosLocalidade()
        {
            SqlDataReader drLer;
            execComandos.Conexao = cnConexao;
            drLer = null;
            List<Localidade> _Localidade = new List<Localidade>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaTodasLocalidades();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Localidade.Add(new Localidade()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                Nome_localidade = drLer["Nome_Localidade"].ToString(),
                                Cod_Municipio = int.Parse(drLer["Cod_Municipio"].ToString())
                            });
                        }
                    }
                    execComandos.Desconectar();
                }
            }
            return _Localidade;
        }

        public bool seExisteLocalidade(string sNome_localidade)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeLocalidade(sNome_localidade);
                }
            }
            return bResposta;
        }

        //Metodos - Bairro
        public bool gravarBairro(Bairro cBairro, byte vTipo)
        {
            bool bResposta = true;

            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    switch (vTipo)
                    {
                        case 0:
                            //novo
                            cBairro.Codigo = execComandos.ultimoCodigoBairro();
                            cBairro.Codigo++;
                            if (cBairro.Codigo != 0)
                            {
                                if (!execComandos.inserirBairro(cBairro.Codigo, cBairro.Nome_bairro, cBairro.Cod_localidade)) bResposta = false;
                            }
                            else
                            {
                                bResposta = false;
                            }
                            break;
                        case 1:
                            //alterar
                            if (!execComandos.alterarBairro(cBairro.Codigo, cBairro.Nome_bairro, cBairro.Cod_localidade)) bResposta = false;
                            break;
                    }

                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            return bResposta;
        }

        public Bairro pesquisarBairro(int vvCod)
        {
            SqlDataReader drLer;
            Bairro cBairro = new Bairro();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaBairro(vvCod);
                    if (drLer.HasRows)
                    {
                        if (drLer.Read())
                        {
                            cBairro.Codigo = int.Parse(drLer["codigo"].ToString());
                            cBairro.Nome_bairro = drLer["Nome_bairro"].ToString();
                            cBairro.Cod_localidade = int.Parse(drLer["Cod_localidade"].ToString());
                        }
                    }
                    return cBairro;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;

        }

        public Bairro pesquisarBairro(string sNomeBairro)
        {
            Bairro cBairro = new Bairro();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    cBairro = execComandos.pesquisaBairro(sNomeBairro);
                    return cBairro;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;

        }

        /// <summary>
        /// Função para pesquisar os Bairros de uma localidade
        /// </summary>
        /// <param name="iCodigoLocalidade">Código da localidade para a pesquisa</param>
        /// <returns>Retorna uma lista de Bairros da localidade passada</returns>
        public List<Bairro> pesquisarBairro(int iCodigoLocalidade,byte bTipo = 0)
        {
            List<Bairro> lstBairro = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstBairro = execComandos.pesquisaBairro(iCodigoLocalidade, bTipo);
                    return lstBairro;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;
        }

        public bool excluirBairro(int vvCod)
        {
            bool bResposta = true;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (!execComandos.excluirBairro(vvCod)) bResposta = false;
                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            return bResposta;
        }

        
        public List<Bairro> pesquisarTodosBairro()
        {
            SqlDataReader drLer;
            execComandos.Conexao = cnConexao;
            drLer = null;
            List<Bairro> _Bairro = new List<Bairro>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaTodosBairro();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Bairro.Add(new Bairro()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                Nome_bairro = drLer["Nome_bairro"].ToString(),
                                Cod_localidade = int.Parse(drLer["Cod_localidade"].ToString())
                            });
                        }
                    }
                    execComandos.Desconectar();
                }
            }
            return _Bairro;
        }

        public bool seExisteBairro(string sNome_bairro)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeBairro(sNome_bairro);
                }
            }
            return bResposta;
        }

        // Metodos - Logradouro
        public bool gravarLogradouro(Logradouro cLogradouro, byte vTipo)
        {
            bool bResposta = true;

            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    switch (vTipo)
                    {
                        case 0:
                            //novo
                            cLogradouro.Codigo = execComandos.ultimoCodigoLogradouro();
                            cLogradouro.Codigo++;
                            if (cLogradouro.Codigo != 0)
                            {
                                if (!execComandos.inserirLogradouro(cLogradouro.Codigo, cLogradouro.Tipo, cLogradouro.Nome_logradouro, cLogradouro.CEP, cLogradouro.Cod_bairro)) bResposta = false;
                            }
                            else
                            {
                                bResposta = false;
                            }
                            break;
                        case 1:
                            //alterar
                            if (!execComandos.alterarLogradouro(cLogradouro.Codigo, cLogradouro.Tipo, cLogradouro.Nome_logradouro, cLogradouro.CEP, cLogradouro.Cod_bairro)) bResposta = false;
                            break;
                    }

                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            return bResposta;
        }

        public Logradouro pesquisarLogradouro(int vvCod)
        {
            SqlDataReader drLer;
            Logradouro cLogradouro = new Logradouro();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaLogradouro(vvCod);
                    if (drLer.HasRows)
                    {
                        if (drLer.Read())
                        {
                            cLogradouro.Codigo = int.Parse(drLer["codigo"].ToString());
                            cLogradouro.Nome_logradouro = drLer["Nome_logradouro"].ToString();
                            cLogradouro.CEP = drLer["CEP"].ToString();
                            cLogradouro.Tipo = int.Parse(drLer["Tipo"].ToString());
                            cLogradouro.Cod_bairro = int.Parse(drLer["Cod_bairro"].ToString());
                        }
                    }
                    return cLogradouro;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;
        }

        public Logradouro pesquisarLogradouro(string sLogradouro)
        {            
            Logradouro cLogradouro = new Logradouro();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    return execComandos.pesquisaLogradouro(sLogradouro);
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;
        }

        /// <summary>
        /// Função para pesquisar logradouro
        /// </summary>
        /// <param name="iCodigoBairro">Código do bairro</param>
        /// <param name="bTipo">Tipo</param>
        /// <returns>Retorna uma lista de logradouro pelo bairro</returns>
        public List<Logradouro> pesquisarLogradouro(int iCodigoBairro, byte bTipo = 0)
        {
            List<Logradouro> lstLogradouro = null;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    lstLogradouro = execComandos.pesquisaLogradouro(iCodigoBairro, bTipo);
                    return lstLogradouro;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;
        }

        public bool excluirLogradouro(int vvCod)
        {
            bool bResposta = true;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    if (!execComandos.excluirLogradouro(vvCod)) bResposta = false;
                    execComandos.Desconectar();
                }
                else
                {
                    bResposta = false;
                }
            }
            return bResposta;
        }

        public bool seExisteLogradouro(string sNome_Logradouro)
        {
            bool bResposta = false;
            execComandos.Conexao = cnConexao;
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    bResposta = execComandos.existeLogradouro(sNome_Logradouro);
                }
            }
            return bResposta;
        }

        public List<Logradouro> pesquisarTodosLogradouro()
        {
            SqlDataReader drLer;
            execComandos.Conexao = cnConexao;
            drLer = null;
            List<Logradouro> _Logradouro = new List<Logradouro>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaTodasLogradouro();
                    if (drLer.HasRows)
                    {
                        while (drLer.Read())
                        {
                            _Logradouro.Add(new Logradouro()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                Nome_logradouro = drLer["Nome_logradouro"].ToString(),
                                Tipo = int.Parse(drLer["Tipo"].ToString()),
                                Cod_bairro = int.Parse(drLer["Cod_bairro"].ToString())
                            });
                        }
                    }
                    execComandos.Desconectar();
                }
            }
            return _Logradouro;
        }

        public bool preparaBancoDados()
        {
            bool bResposta = true;

            if (execComandos.buscarDadosConexao(sArquivoConexao))
            {
                this.sServidor = execComandos.vvServidor;
                this.sDataBase = execComandos.vvDataBase;
                this.sUsuario = execComandos.vvUser;
                this.sSenha = execComandos.vvPass;
                this.iPortaAcesso = execComandos.vvPorta;
                this.sChaveAcesso = execComandos.vvChaveAcesso;
            }
            else
            {
                bResposta = false;
            }
            return bResposta;
        }

        //Logradouro_tipo
        public List<Logradouro_tipo> pesquisarTodosLogradouro_Tipo()
        {
            SqlDataReader drLer;
            execComandos.Conexao = cnConexao;
            drLer = null;
            List<Logradouro_tipo> _Tipo = new List<Logradouro_tipo>();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaTodasLogradouro_Tipo();
                    if (drLer.HasRows)  
                    {
                        while (drLer.Read())
                        {
                            _Tipo.Add(new Logradouro_tipo()
                            {
                                Codigo = int.Parse(drLer["Codigo"].ToString()),
                                Tipo = drLer["tipo"].ToString(),
                                Abreviacao = drLer["Abreviacao"].ToString()
                            });
                        }
                    }
                    execComandos.Desconectar();
                }
            }
            return _Tipo;
        }

        public Logradouro_tipo pesquisarLogradouro_tipo(int vvCod)
        {
            SqlDataReader drLer;
            Logradouro_tipo cTipo = new Logradouro_tipo();
            if (preparaBancoDados())
            {
                if (execComandos.Conectar(sServidor, sDataBase, sUsuario, sSenha, iPortaAcesso))
                {
                    drLer = execComandos.pesquisaLogradouro_tipo(vvCod);
                    if (drLer.HasRows)
                    {
                        if (drLer.Read())
                        {
                            cTipo.Codigo = int.Parse(drLer["codigo"].ToString());
                            cTipo.Tipo = drLer["Tipo"].ToString();
                            cTipo.Abreviacao = drLer["Abreviacao"].ToString();
                        }
                    }
                    return cTipo;
                    execComandos.Desconectar();
                }
                else
                    return null;
            }
            else
                return null;
        }
    }

}
