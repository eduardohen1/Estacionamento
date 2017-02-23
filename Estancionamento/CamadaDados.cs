using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Estancionamento
{

    public class funcoes
    {
        public bool isNumeric(System.Object Expressao)
        {
            if (Expressao == null || Expressao is DateTime)
                return false;
            if (Expressao is Int16 || Expressao is Int32 || Expressao is Int64 || Expressao is Decimal || Expressao is Single || Expressao is Double || Expressao is Boolean)
                return true;
            try
            {
                if (Expressao is string)
                    Double.Parse(Expressao as string);
                else
                    Double.Parse(Expressao.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    class CamadaDados : Conexao
    {
        SqlConnection cnConexao;
        public SqlConnection Conexao
        {
            set { cnConexao = value; }
        }

        public bool abrirConexao()
        {
            bool bResposta = true;
            try
            {
                cnConexao.Open();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao abrir conexão com o banco de dados! " + ex.Message, "EstacionamentoFacil (03)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        public bool fecharConexao()
        {
            bool bResposta = true;
            try
            {
                cnConexao.Close();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao fechar conexão com o banco de dados! " + ex.Message, "EstacionamentoFacil (04)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        public SqlDataReader retornaComandoList(string sSQL)
        {
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public bool executarComando(string sSQL)
        {
            bool bResposta = true;

            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (02)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }

        public bool inserirLocalidade(int iCodigo, string sNomeLocalidade, int iCodMunicipio)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "INSERT INTO Localidade(Codigo, Nome_localidade, Cod_municipio) VALUES(@Codigo, @NomeLocalidade, @CodigoMunicipio)";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.Parameters.Add(new SqlParameter("@NomeLocalidade", sNomeLocalidade));
                cmComando.Parameters.Add(new SqlParameter("@CodigoMunicipio", iCodMunicipio));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (02)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        public bool alterarLocalidade(int iCodigo, string sNomeLocalidade, int iCodMunicipio)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "UPDATE Localidade SET Nome_localidade = @NomeLocalidade, Cod_municipio = @CodigoMunicipio WHERE Codigo = @Codigo";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@NomeLocalidade", sNomeLocalidade));
                cmComando.Parameters.Add(new SqlParameter("@CodigoMunicipio", iCodMunicipio));
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (02)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }
        public bool excluirLocalidade(int iCodigo)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM Localidade WHERE Codigo = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Localidade");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (05)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        
        public SqlDataReader pesquisaLocalidade(int iCodigo)
        {
            string sSQL = "SELECT * FROM Localidade WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Localidade> pesquisaLocalidade(int iCodMunicipio, byte bTipo = 0)
        {
            List<Localidade> lstLocalidade = null;
            string sSQL = "SELECT * FROM Localidade WHERE Cod_municipio = @Codigo ORDER BY Nome_localidade";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodMunicipio));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstLocalidade = new List<Localidade>();
                    while (drLer.Read())
                    {
                        lstLocalidade.Add(new Localidade()
                        {
                            Codigo = int.Parse(drLer["Codigo"].ToString()),
                            Nome_localidade = drLer["Nome_localidade"].ToString(),
                            Cod_Municipio = int.Parse(drLer["Cod_municipio"].ToString())
                        });
                    }
                }
                return lstLocalidade;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public Localidade pesquisaLocalidade(string sLocalidade)
        {
            Localidade cLocalidade = null;
            string sSQL = "SELECT * FROM Localidade WHERE Nome_localidade = '" + sLocalidade + "'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    cLocalidade = new Localidade();
                    if (drLer.Read())
                    {
                        cLocalidade.Cod_Municipio = int.Parse(drLer["Cod_municipio"].ToString());
                        cLocalidade.Nome_localidade = drLer["Nome_localidade"].ToString().Trim();
                        cLocalidade.Codigo = int.Parse(drLer["Codigo"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (01)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                
            }
            return cLocalidade;
        }

        public SqlDataReader pesquisaTodasLocalidades()
        {
            string sSQL = "SELECT * FROM Localidade ORDER BY Nome_localidade";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09e)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public bool existeLocalidade(string sNomeLocalidade)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Localidade WHERE nome_localidade LIKE '%" + sNomeLocalidade + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0)
                            bResposta = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09f)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        public int ultimoCodigoLocalidade()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Localidade";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09g)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        //Municipio
        public bool inserirMunicipio(int iCodigo, string sNomeMunicipio, string sUF)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "INSERT INTO Municipio(codigo, nome_municipio, UF) VALUES(@codigo, @NomeMunicipio, @UF)";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                cmComando.Parameters.Add(new SqlParameter("@NomeMunicipio", sNomeMunicipio));
                cmComando.Parameters.Add(new SqlParameter("@UF", sUF));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (06)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        public bool alterarMunicipio(int iCodigo, string sNomeMunicipio, string sUF)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "UPDATE Municipio SET Nome_Municipio = @NomeMunicipio, UF = @UF WHERE Codigo = @Codigo";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@NomeMunicipio", sNomeMunicipio));
                cmComando.Parameters.Add(new SqlParameter("@UF", sUF));
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de alteração cadastral! " + ex.Message, "EstacionamentoFacil (07)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }

        public bool excluirMunicipio(int iCodigo)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM Municipio WHERE Codigo = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Municipio");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (08)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        public Municipio pesquisaMunicipio(int iCodigo)
        {
            Municipio lstMunicipio = null;
            string sSQL = "SELECT * FROM Municipio WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();

                if (drLer.HasRows)
                {
                    lstMunicipio = new Municipio();
                    if (drLer.Read())
                    {
                        lstMunicipio = new Municipio()
                        {
                            Codigo = int.Parse(drLer["Codigo"].ToString()),
                            Nome_municipio = drLer["Nome_municipio"].ToString(),
                            UF = drLer["UF"].ToString()
                        };
                    }
                }
                return lstMunicipio;
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public Municipio pesquisaMunicipio(string sMunicipio)
        {
            Municipio lstMunicipio = null;
            string sSQL = "SELECT * FROM Municipio WHERE Nome_municipio = '" + sMunicipio + "'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();

                if (drLer.HasRows)
                {
                    lstMunicipio = new Municipio();
                    if (drLer.Read())
                    {
                        lstMunicipio = new Municipio()
                        {
                            Codigo = int.Parse(drLer["Codigo"].ToString()),
                            Nome_municipio = drLer["Nome_municipio"].ToString(),
                            UF = drLer["UF"].ToString()
                        };
                    }
                }
                return lstMunicipio;
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Municipio> pesquisaTodosMunicipio()
        {
            List<Municipio> lstMunicipio = null;
            string sSQL = "SELECT * FROM Municipio ORDER BY Nome_Municipio";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstMunicipio = new List<Municipio>();
                    while (drLer.Read())
                    {
                        lstMunicipio.Add(new Municipio()
                        {
                            Codigo = int.Parse(drLer["Codigo"].ToString()),
                            Nome_municipio = drLer["Nome_municipio"].ToString(),
                            UF = drLer["UF"].ToString()
                        });
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
                return lstMunicipio;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public bool existeMunicipio(string sNomeMunicipio)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Municipio WHERE nome_municipio LIKE '%" + sNomeMunicipio + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0)
                            bResposta = true;
                    }
                }
                drLer.Close();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09c)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        public int ultimoCodigoMunicipio()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Municipio";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Close();
                cmComando.Dispose();                
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (09d)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        //Bairro
        public bool inserirBairro(int iCodigo, string sNomeBairro, int iCod_Localidade)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "INSERT INTO Bairro(codigo, nome_bairro, cod_localidade) VALUES(@Codigo, @NomeBairro, @CodLocalidade)";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.Parameters.Add(new SqlParameter("@NomeBairro", sNomeBairro));
                cmComando.Parameters.Add(new SqlParameter("@CodLocalidade", iCod_Localidade));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (10)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        public bool alterarBairro(int iCodigo, string sNomeBairro, int iCod_Localidade)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "UPDATE Bairro SET nome_bairro = @NomeBairro, Cod_localidade = @CodLocalidade WHERE Codigo = @Codigo";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@NomeBairro", sNomeBairro));
                cmComando.Parameters.Add(new SqlParameter("@CodLocalidade", iCod_Localidade));
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de alteração cadastral! " + ex.Message, "EstacionamentoFacil (11)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }
        public bool excluirBairro(int iCodigo)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM Bairro WHERE Codigo = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Bairro");                    
                else
                    System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (12)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        public SqlDataReader pesquisaBairro(int iCodigo)
        {
            string sSQL = "SELECT * FROM Bairro WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (13)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Bairro> pesquisaBairro(int iCodigoLocalidade, byte bTipo = 0)
        {
            List<Bairro> lstBairro = null;
            string sSQL = "SELECT * FROM Bairro WHERE Cod_localidade = @Codigo ORDER BY Nome_bairro";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigoLocalidade));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstBairro = new List<Bairro>();
                    while (drLer.Read())
                    {
                        lstBairro.Add(new Bairro()
                        {
                            Codigo = int.Parse(drLer["Codigo"].ToString()),
                            Nome_bairro = drLer["Nome_bairro"].ToString().Trim(),
                            Cod_localidade = int.Parse(drLer["Cod_localidade"].ToString())
                        });
                    }
                }
                return lstBairro;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (13b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public Bairro pesquisaBairro(string sNomeBairro)
        {
            Bairro cBairro;
            string sSQL = "SELECT * FROM Bairro WHERE Nome_bairro = '" + sNomeBairro + "'";
            try
            {
                cBairro = new Bairro();
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);                
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cBairro.Codigo = int.Parse(drLer["Codigo"].ToString());
                        cBairro.Cod_localidade = int.Parse(drLer["Cod_localidade"].ToString());
                        cBairro.Nome_bairro = drLer["Nome_bairro"].ToString();
                    }
                }
                return cBairro;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (13b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public SqlDataReader pesquisaTodosBairro()
        {
            string sSQL = "SELECT * FROM Bairro ORDER BY Nome_bairro";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (13a)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public bool existeBairro(string sNomeBairro)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Bairro WHERE nome_bairro LIKE '%" + sNomeBairro + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0)
                            bResposta = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (13b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        public int ultimoCodigoBairro()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Bairro";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (13c)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        //logradouro
        public bool inserirLogradouro(int iCodigo, int iTipo, string sNomeLogradouro, string sCEP, int iCodBairro)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "INSERT INTO Logradouro(Codigo, Tipo, nome_logradouro, CEP, Cod_bairro) VALUES(@Codigo, @Tipo, @NomeLogradouro, @CEP, @CodBairro)";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.Parameters.Add(new SqlParameter("@Tipo", iTipo));
                cmComando.Parameters.Add(new SqlParameter("@NomeLogradouro", sNomeLogradouro));
                cmComando.Parameters.Add(new SqlParameter("@CEP", sCEP));
                cmComando.Parameters.Add(new SqlParameter("@CodBairro", iCodBairro));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (14)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        public bool alterarLogradouro(int iCodigo, int iTipo, string sNomeLogradouro, string sCEP, int iCodBairro)
        {
            bool bResposta = true;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                sSQL = "UPDATE Logradouro SET tipo = @Tipo, nome_logradouro = @NomeLogradouro, CEP = @CEP, Cod_Bairro = @CodBairro WHERE Codigo = @Codigo";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Tipo", iTipo));
                cmComando.Parameters.Add(new SqlParameter("@NomeLogradouro", sNomeLogradouro));
                cmComando.Parameters.Add(new SqlParameter("@CEP", sCEP));
                cmComando.Parameters.Add(new SqlParameter("@CodBairro", iCodBairro));
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de alteração cadastral! " + ex.Message, "EstacionamentoFacil (15)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }

            return bResposta;
        }
        public bool excluirLogradouro(int iCodigo)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM Logradouro WHERE Codigo = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Logradouro");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (16)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
        public SqlDataReader pesquisaLogradouro(int iCodigo)
        {
            string sSQL = "SELECT * FROM Logradouro WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (17)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public Logradouro pesquisaLogradouro(string sLogradouro)
        {
            Logradouro cLogradouro = new Logradouro();
            string sSQL = "SELECT * FROM Logradouro WHERE Nome_logradouro = '" + sLogradouro + "'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    cLogradouro = new Logradouro();
                    if (drLer.Read())
                    {
                        cLogradouro.Codigo = int.Parse(drLer["Codigo"].ToString());
                        cLogradouro.Tipo = int.Parse(drLer["Tipo"].ToString());
                        cLogradouro.Nome_logradouro = drLer["Nome_logradouro"].ToString().Trim();
                        cLogradouro.CEP = drLer["CEP"].ToString().Trim();
                        cLogradouro.Cod_bairro = int.Parse(drLer["Cod_logradouro"].ToString());
                    }
                }
                return cLogradouro;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (17b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Logradouro> pesquisaLogradouro(int iCodigoBairro, byte bTipo = 0)
        {
            List<Logradouro> lstLogradouro = null;
            string sSQL = "SELECT * FROM Logradouro WHERE Cod_bairro = @Codigo ORDER BY Nome_logradouro";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigoBairro));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstLogradouro = new List<Logradouro>();
                    while (drLer.Read())
                    {
                        lstLogradouro.Add(new Logradouro()
                        {
                            Codigo = int.Parse(drLer["Codigo"].ToString()),
                            Nome_logradouro = drLer["Nome_logradouro"].ToString(),
                            CEP = drLer["CEP"].ToString(),
                            Cod_bairro = int.Parse(drLer["Cod_bairro"].ToString()),
                            Tipo = int.Parse(drLer["Tipo"].ToString())
                        });
                    }
                }
                return lstLogradouro;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (13b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public string buscaNivelAcesso(int iNivel)
        {
            string sResposta = "";
            string sSQL = "SELECT nivelacesso FROM Usuarios_NivelAcesso WHERE codigo = @Codigo";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iNivel));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        sResposta = drLer["nivelacesso"].ToString();
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (18)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return "";
            }
            return sResposta;
        }

        public SqlDataReader pesquisaUsuario(string sUsuario, string sSenha)
        {
            Funcoes funcoes = new Funcoes();
            sSenha = funcoes.Criptografar(sSenha);

            string sSQL = "SELECT * FROM Usuarios WHERE usuario = @Usuario AND senha = @Senha";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Usuario", sUsuario));
                cmComando.Parameters.Add(new SqlParameter("@Senha", sSenha));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (19)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public SqlDataReader pesquisaTodasLogradouro()
        {
            string sSQL = "SELECT * FROM Logradouro ORDER BY Nome_logradouro";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (19a)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        //Logradouro_tipo
        public SqlDataReader pesquisaTodasLogradouro_Tipo()
        {
            string sSQL = "SELECT * FROM Logradouro_Tipo ORDER BY Tipo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (19b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public SqlDataReader pesquisaLogradouro_tipo(int iCodigo)
        {
            string sSQL = "SELECT * FROM Logradouro_tipo WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (19c)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public bool existeLogradouro(string sNomeLogradouro)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Logradouro WHERE nome_logradouro LIKE '%" + sNomeLogradouro + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                //cmComando.Parameters.Add(new SqlParameter("@Logradouro", sNomeLogradouro));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0)
                            bResposta = true;
                    }
                }
                drLer.Close();
                drLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (19d)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        public int ultimoCodigoLogradouro()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Logradouro";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (19e)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        //clientes
        /// <summary>
        /// Função para gerar o último código de cliente
        /// </summary>
        /// <returns>Retorna o último código de cliente</returns>
        public int ultimoCodigoCliente()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Cliente";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (20)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        /// <summary>
        /// Função para inserir/atualizar clientes
        /// </summary>
        /// <param name="cCliente">Objeto cliente já preenchido</param>
        /// <param name="bTipo">Tipo de operação (0 insert, 1 update)</param>
        /// <returns>Retorna verdadeiro ou false, mediante a operação executada</returns>
        public bool inserirAtualizarCliente(cliente cCliente, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        // novo
                        sSQL = "INSERT INTO Cliente(Codigo, Nome, CPF, RG, Email, Cod_logradouro, Numero, Observacao, telefone, celular, TipoCliente, TipoPessoa, DtNascimento, DtCadastro, DtRenovacaoSeguro, Profissao, Status, Sexo, EstadoCivil, FaixaSalarial, ValidadeCNH, CategoriaCNH, DtPrimeiraCNH, CNH) VALUES(@Codigo, @Nome, @CPF, @RG, @Email, @Cod_logradouro, @Numero, @Observacao, '','',@TipoCliente,@TipoPessoa,@DtNascimento,@DtCadastro,@DtRenovacaoSeguro,@Profissao,@Status,@Sexo,@EstadoCivil,@FaixaSalarial,@ValidadeCNH,@CategoriaCNH, @DtPrimeiraCNH, @CNH)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cCliente.Codigo));
                        cmComando.Parameters.Add(new SqlParameter("@Nome", cCliente.Nome));
                        cmComando.Parameters.Add(new SqlParameter("@CPF", cCliente.CPF));
                        cmComando.Parameters.Add(new SqlParameter("@RG", cCliente.RG));
                        cmComando.Parameters.Add(new SqlParameter("@Email", cCliente.Email));
                        cmComando.Parameters.Add(new SqlParameter("@Cod_logradouro", cCliente.Cod_logradouro));
                        cmComando.Parameters.Add(new SqlParameter("@Numero", cCliente.Numero));
                        cmComando.Parameters.Add(new SqlParameter("@Observacao", cCliente.Observacao));
                        cmComando.Parameters.Add(new SqlParameter("@TipoCliente", cCliente.TipoCliente));
                         
                        cmComando.Parameters.Add(new SqlParameter("@TipoPessoa", cCliente.TipoPessoa));
                        cmComando.Parameters.Add(new SqlParameter("@DtNascimento", cCliente.DtNascimento));
                        cmComando.Parameters.Add(new SqlParameter("@DtCadastro", cCliente.DtCadastro));
                        cmComando.Parameters.Add(new SqlParameter("@DtRenovacaoSeguro", cCliente.DtRenovacaoSeguro));
                        cmComando.Parameters.Add(new SqlParameter("@Profissao", cCliente.Profissao));
                        cmComando.Parameters.Add(new SqlParameter("@Status", cCliente.Status));
                        cmComando.Parameters.Add(new SqlParameter("@Sexo", cCliente.Sexo));
                        cmComando.Parameters.Add(new SqlParameter("@EstadoCivil", cCliente.EstadoCivil));
                        cmComando.Parameters.Add(new SqlParameter("@FaixaSalarial", cCliente.FaixaSalarial));
                        cmComando.Parameters.Add(new SqlParameter("@ValidadeCNH", cCliente.ValidadeCNH));
                        cmComando.Parameters.Add(new SqlParameter("@CategoriaCNH", cCliente.CategoriaCNH));
                        cmComando.Parameters.Add(new SqlParameter("@DtPrimeiraCNH", cCliente.DtPrimeiraCNH));
                        cmComando.Parameters.Add(new SqlParameter("@CNH", cCliente.CNH));
                        
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        //atualizar:
                        sSQL = "UPDATE Cliente SET Nome = @Nome, CPF = @CPF, RG = @RG, Email = @Email, Cod_logradouro = @Cod_logradouro, Numero = @Numero, Observacao = @Observacao, TipoPessoa = @TipoPessoa, DtNascimento = @DtNascimento, DtCadastro = @DtCadastro, DtRenovacaoSeguro = @DtRenovacaoSeguro, Profissao = @Profissao, Status = @Status, Sexo = @Sexo, EstadoCivil = @EstadoCivil, FaixaSalarial = @FaixaSalarial, ValidadeCNH = @ValidadeCNH, CategoriaCNH = @CategoriaCNH, DtPrimeiraCNH = @DtPrimeiraCNH, CNH = @CNH WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Nome", cCliente.Nome));
                        cmComando.Parameters.Add(new SqlParameter("@CPF", cCliente.CPF));
                        cmComando.Parameters.Add(new SqlParameter("@RG", cCliente.RG));
                        cmComando.Parameters.Add(new SqlParameter("@Email", cCliente.Email));
                        cmComando.Parameters.Add(new SqlParameter("@Cod_logradouro", cCliente.Cod_logradouro));
                        cmComando.Parameters.Add(new SqlParameter("@Numero", cCliente.Numero));
                        cmComando.Parameters.Add(new SqlParameter("@Observacao", cCliente.Observacao));
                        
                        cmComando.Parameters.Add(new SqlParameter("@TipoPessoa", cCliente.TipoPessoa));
                        cmComando.Parameters.Add(new SqlParameter("@DtNascimento", cCliente.DtNascimento));
                        cmComando.Parameters.Add(new SqlParameter("@DtCadastro", cCliente.DtCadastro));
                        cmComando.Parameters.Add(new SqlParameter("@DtRenovacaoSeguro", cCliente.DtRenovacaoSeguro));
                        cmComando.Parameters.Add(new SqlParameter("@Profissao", cCliente.Profissao));
                        cmComando.Parameters.Add(new SqlParameter("@Status", cCliente.Status));
                        cmComando.Parameters.Add(new SqlParameter("@Sexo", cCliente.Sexo));
                        cmComando.Parameters.Add(new SqlParameter("@EstadoCivil", cCliente.EstadoCivil));
                        cmComando.Parameters.Add(new SqlParameter("@FaixaSalarial", cCliente.FaixaSalarial));
                        cmComando.Parameters.Add(new SqlParameter("@ValidadeCNH", cCliente.ValidadeCNH));
                        cmComando.Parameters.Add(new SqlParameter("@CategoriaCNH", cCliente.CategoriaCNH));
                        cmComando.Parameters.Add(new SqlParameter("@DtPrimeiraCNH", cCliente.DtPrimeiraCNH));
                        cmComando.Parameters.Add(new SqlParameter("@CNH", cCliente.CNH));

                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cCliente.Codigo));

                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }

            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (21)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar os dados de um determinado cliente
        /// </summary>
        /// <param name="iCodigo">Código do cliente a ser pesquisado</param>
        /// <returns>Retorna o objeto cliente já preenchido</returns>
        public cliente pesquisaCliente(int iCodigo)
        {
            cliente cCliente = new cliente();
            string sSQL = "SELECT * FROM Cliente WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cCliente.Codigo = int.Parse(drLer["Codigo"].ToString());
                        cCliente.Nome = drLer["Nome"].ToString();
                        cCliente.CPF = drLer["CPF"].ToString();
                        cCliente.RG = drLer["RG"].ToString();
                        cCliente.Cod_logradouro = int.Parse(drLer["Cod_logradouro"].ToString());
                        cCliente.Numero = int.Parse(drLer["Numero"].ToString());
                        cCliente.Email = drLer["Email"].ToString();
                        cCliente.Observacao = drLer["Observacao"].ToString();
                        cCliente.TipoCliente = int.Parse(drLer["TipoCliente"].ToString());

                        cCliente.TipoPessoa = int.Parse(drLer["TipoPessoa"].ToString());
                        cCliente.DtNascimento = DateTime.Parse(drLer["DtNascimento"].ToString());
                        cCliente.DtCadastro = DateTime.Parse(drLer["DtCadastro"].ToString());
                        cCliente.DtRenovacaoSeguro = DateTime.Parse(drLer["DtRenovacaoSeguro"].ToString());
                        cCliente.Profissao = drLer["Profissao"].ToString();
                        cCliente.Status = int.Parse(drLer["Status"].ToString());
                        cCliente.Sexo = int.Parse(drLer["Sexo"].ToString());
                        cCliente.EstadoCivil = drLer["EstadoCivil"].ToString();
                        cCliente.FaixaSalarial = int.Parse(drLer["FaixaSalarial"].ToString());
                        cCliente.CNH = drLer["CNH"].ToString();
                        cCliente.ValidadeCNH = DateTime.Parse(drLer["ValidadeCNH"].ToString());
                        cCliente.CategoriaCNH = drLer["CategoriaCNH"].ToString();
                        cCliente.DtPrimeiraCNH = DateTime.Parse(drLer["DtPrimeiraCNH"].ToString());
                        
                        return cCliente;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (22)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os clientes cadastrados
        /// </summary>
        /// <returns>Retorna um DataReader contendo o resultado da pesquisa</returns>
        public SqlDataReader pesquisarTodosClientes()
        {
            string sSQL = "SELECT * FROM Cliente ORDER BY Nome";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (23)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para excluir um cliente existente na base de dados
        /// </summary>
        /// <param name="iCodigo">Código do cliente a ser excluído</param>
        /// <returns>Retorno verdadeiro ou falso conforme a execução da função</returns>
        public bool excluirCliente(int iCodigo)
        {
            bool bResposta = false;
            //string sSQL = "DELETE FROM Cliente WHERE Codigo = @Codigo";
            string sSQL = "UPDATE Cliente SET TipoCliente = 3, Nome = '@' + Nome WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Cliente");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (24)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificação se existe um determinado Cliente
        /// </summary>
        /// <param name="sNome">Nome digitado</param>
        /// <returns>Retorna verdadeiro ou falso</returns>
        public bool existeCliente(string sNome)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Cliente WHERE nome LIKE '%" + sNome + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0)
                            bResposta = true;
                    }
                }
                drLer.Close();
                drLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (25)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o último código de telefone cadastrado
        /// </summary>
        /// <returns></returns>
        public int ultimoCodigoTelefone()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codtelefone) vCodigo FROM Telefone";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (26)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        /// <summary>
        /// Função para inserir/atualizar registro de telefones de vendedor
        /// </summary>
        /// <param name="cTelefone">Objeto telefone</param>
        /// <param name="cVendedor">Objeto vendedor</param>
        /// <param name="bTipo">Tipo 0 para novo registro, 1 para atualizar registro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarTelefoneVendedor(Telefones cTelefone, vendedor cVendedor, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        // novo
                        sSQL = "INSERT INTO telefone(codtelefone, codoperadora, ddd, telefone, tipotelefone, telefonedq) VALUES(@codtelefone, @codoperadora, @ddd, @telefone, @tipotelefone,@telefonedq)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@codtelefone", cTelefone.CodigoTelefone));
                        cmComando.Parameters.Add(new SqlParameter("@codoperadora", cTelefone.codoperadora));
                        cmComando.Parameters.Add(new SqlParameter("@ddd", cTelefone.ddd));
                        cmComando.Parameters.Add(new SqlParameter("@telefone", cTelefone.telefone));
                        cmComando.Parameters.Add(new SqlParameter("@tipotelefone", cTelefone.tipotelefone));
                        cmComando.Parameters.Add(new SqlParameter("@telefonedq", cTelefone.telefonedq));
                        cmComando.ExecuteNonQuery();

                        cmComando.Dispose();
                        sSQL = "INSERT INTO TelefonesVendedor(CodigoTelefone, CodigoVendedor) VALUES(@codtelefone, @codvendedor)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);                        
                        cmComando.Parameters.Add(new SqlParameter("@codtelefone", cTelefone.CodigoTelefone));
                        cmComando.Parameters.Add(new SqlParameter("@codvendedor", cVendedor.código));
                        cmComando.ExecuteNonQuery();
                        cmComando.Dispose();

                        bResposta = true;
                        break;
                    case 1:
                        //atualizar:
                        sSQL = "UPDATE telefone SET codoperadora = @codoperadora, ddd = @ddd, telefone = @telefone, tipotelefone = @tipotelefone WHERE codtelefone = @codtelefone";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@codoperadora", cTelefone.codoperadora));
                        cmComando.Parameters.Add(new SqlParameter("@ddd", cTelefone.ddd));
                        cmComando.Parameters.Add(new SqlParameter("@telefone", cTelefone.telefone));
                        cmComando.Parameters.Add(new SqlParameter("@tipotelefone", cTelefone.tipotelefone));
                        cmComando.Parameters.Add(new SqlParameter("@codtelefone", cTelefone.CodigoTelefone));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }

            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (27b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para inserir/atualizar registro de telefone
        /// </summary>
        /// <param name="cTelefone">Objeto telefone</param>
        /// <param name="bTipo">0 para novo registro / 1 para atualizar registro</param>
        /// <returns>Retorna verdadeiro ou falso conforme a execução do comando</returns>
        public bool inserirAtualizarTelefone(Telefones cTelefone, cliente cCliente, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        // novo
                        sSQL = "INSERT INTO telefone(codtelefone, codoperadora, ddd, telefone, tipotelefone, telefonedq) VALUES(@codtelefone, @codoperadora, @ddd, @telefone, @tipotelefone,@telefonedq)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@codtelefone", cTelefone.CodigoTelefone));
                        cmComando.Parameters.Add(new SqlParameter("@codoperadora", cTelefone.codoperadora));
                        cmComando.Parameters.Add(new SqlParameter("@ddd", cTelefone.ddd));
                        cmComando.Parameters.Add(new SqlParameter("@telefone", cTelefone.telefone));
                        cmComando.Parameters.Add(new SqlParameter("@tipotelefone", cTelefone.tipotelefone));
                        cmComando.Parameters.Add(new SqlParameter("@telefonedq", cTelefone.telefonedq));
                        cmComando.ExecuteNonQuery();

                        cmComando.Dispose();
                        sSQL = "INSERT INTO TelefonesClientes(CodigoCliente, CodigoTelefone) VALUES(@codcliente, @codtelefone)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@codcliente", cCliente.Codigo));
                        cmComando.Parameters.Add(new SqlParameter("@codtelefone", cTelefone.CodigoTelefone));
                        cmComando.ExecuteNonQuery();
                        cmComando.Dispose();

                        bResposta = true;
                        break;
                    case 1:
                        //atualizar:
                        sSQL = "UPDATE telefone SET codoperadora = @codoperadora, ddd = @ddd, telefone = @telefone, tipotelefone = @tipotelefone WHERE codtelefone = @codtelefone";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@codoperadora", cTelefone.codoperadora));
                        cmComando.Parameters.Add(new SqlParameter("@ddd", cTelefone.ddd));
                        cmComando.Parameters.Add(new SqlParameter("@telefone", cTelefone.telefone));
                        cmComando.Parameters.Add(new SqlParameter("@tipotelefone", cTelefone.tipotelefone));
                        cmComando.Parameters.Add(new SqlParameter("@codtelefone", cTelefone.CodigoTelefone));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }

            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (27)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar os telefones do cliente
        /// </summary>
        /// <param name="iCodigo">Código de cliente</param>
        /// <returns>Lista de telefones</returns>
        public List<Telefones> pesquisaTelefoneCliente(int iCodigo)
        {
            List<Telefones> lstTelefone = new List<Telefones>();
            string sSQL = "SELECT t.* FROM telefone t INNER JOIN TelefonesClientes tc ON tc.CodigoTelefone = t.codtelefone WHERE tc.CodigoCliente = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    while (drLer.Read())
                    {
                        lstTelefone.Add(new Telefones()
                        {
                            CodigoTelefone = int.Parse(drLer["codtelefone"].ToString()),
                            codoperadora = int.Parse(drLer["codoperadora"].ToString()),
                            ddd = drLer["ddd"].ToString(),
                            telefone = drLer["telefone"].ToString(),
                            tipotelefone = int.Parse(drLer["tipotelefone"].ToString())
                        });
                    }
                    return lstTelefone;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (28)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para excluir o telefone e o relacionamento com o cliente
        /// </summary>
        /// <param name="iCodigo">Código do telefone para ser excluído</param>
        /// <returns>Retorna verdadeiro ou falso na execução da função</returns>
        public bool excluirTelefone(int iCodigo)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM TelefonesClientes WHERE CodigoTelefone = @Codigo"; 

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "DELETE FROM Telefone WHERE codtelefone = @Codigo";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Telefone");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (29)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar o último código do cadastro de operadora
        /// </summary>
        /// <returns>Retorna o último código de operadora INT</returns>
        public int ultimoCodigoOperadora()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM operadora";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        if (drLer["vCodigo"].ToString().Length > 0)
                            iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (30)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        /// <summary>
        /// Função para iinserir ou atualizar cadastro de operadora
        /// </summary>
        /// <param name="cOperadora">Objeto operadora</param>
        /// <param name="bTipo">0 - Inserir 1 - Atualizar</param>
        /// <returns>Retorna verdadeiro ou falso dependendo do resultado da função</returns>
        public bool inserirAtualizarOperadora(Operadora cOperadora, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        // novo
                        sSQL = "INSERT INTO Operadora(codigo, operadora) VALUES(@Codigo, @Operadora)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cOperadora.Codigo));
                        cmComando.Parameters.Add(new SqlParameter("@Operadora", cOperadora.operadora));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        //atualizar:
                        sSQL = "UPDATE Operadora SET Operadora = @Operadora WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Operadora", cOperadora.operadora));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cOperadora.Codigo));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }

            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (31)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retorno de operadora
        /// </summary>
        /// <param name="iCodigo">Código da operadora a ser pesquisada</param>
        /// <returns>Retorna o objeto Operadora já preenchido</returns>
        public Operadora pesquisaOperadora(int iCodigo)
        {
            Operadora cOperadora = new Operadora();
            string sSQL = "SELECT * FROM operadora WHERE codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cOperadora.Codigo = int.Parse(drLer["codigo"].ToString());
                        cOperadora.operadora = drLer["operadora"].ToString();
                        return cOperadora;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (32)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para retornar todas as operadoras
        /// </summary>
        /// <returns>Recordset contendo todas as operadoras</returns>
        public SqlDataReader pesquisarTodasOperadoras()
        {
            string sSQL = "SELECT * FROM Operadora ORDER BY Operadora";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (33)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para exclusão de operadora
        /// </summary>
        /// <param name="iCodigo">Código da operadora a ser excluída</param>
        /// <returns>Retorna verdadeiro ou falso dependendo da execução da função</returns>
        public bool excluirOperadora(int iCodigo)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM Operadora WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Operadora");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (34)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar se existe a operadora cadastrada
        /// </summary>
        /// <param name="sNome">Operadora</param>
        /// <returns>Verdadeiro ou falso se existe</returns>
        public bool existeOperadora(string sNome)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Operadora WHERE Operadora LIKE '%" + sNome + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0)
                            bResposta = true;
                    }
                }
                drLer.Close();
                drLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (35)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Exclusão de todos os telefones cadastrados deste usuário
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente para exclusão dos telefones</param>
        /// <returns>Verdadeiro ou falso dependendo da execução da função</returns>
        public bool excluirTodosTelefoneCliente(int iCodigoCliente)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM TelefonesClientes WHERE CodigoCliente = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigoCliente));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "DELETE FROM Telefone WHERE codtelefone NOT IN (SELECT CodigoTelefone FROM TelefonesClientes) AND telefonedq = 0";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);                
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (36)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir todos os registros de veículos do cliente
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente para exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução do programa</returns>
        public bool excluirTodosVeiculosCliente(int iCodigoCliente)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM ClienteCarro WHERE CodigoCliente = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigoCliente));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (36b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir veículo de cliente
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente</param>
        /// <param name="iCodigoCarro">Código do veículo</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirVeiculoCliente(int iCodigoCliente, int iCodigoCarro)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM ClienteCarro WHERE CodigoCliente = @CodigoCliente AND CodigoCarro = @CodigoCarro";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodigoCliente", iCodigoCliente));
                cmComando.Parameters.Add(new SqlParameter("@CodigoCarro", iCodigoCarro));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (36c)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para listar todos os carros que não tem vínculo com outro cliente
        /// </summary>
        /// <param name="sCodigosNaoListar">Códigos de veículos para não listar</param>
        /// <returns>DataReader contendo o result da pesquisa</returns>
        public SqlDataReader pesquisarTodosCarrosSemClientes(string sCodigosNaoListar)
        {
            string sSQL = "SELECT * FROM Carro WHERE Codigo NOT IN (SELECT codigocarro FROM ClienteCarro) ";
            if (sCodigosNaoListar.Trim().Length > 0) sSQL += " AND Codigo NOT IN (" + sCodigosNaoListar.Trim() + ")";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (36e)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para inserir veiculo ao cadastro do cliente
        /// </summary>
        /// <param name="iCodigoCarro">Código do carro</param>
        /// <param name="iCodigoCliente">Código do cliente</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirVeiculoCliente(int iCodigoCarro, int iCodigoCliente)
        {
            bool bResposta = true;
            string sSQL = "INSERT INTO ClienteCarro(CodigoCliente, CodigoCarro) VALUES(@CodigoCliente, @CodigoCarro)";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodigoCliente", iCodigoCliente));
                cmComando.Parameters.Add(new SqlParameter("@CodigoCarro", iCodigoCarro));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de atualização! " + ex.Message, "EstacionamentoFacil (36d)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o último código da tabela Carro
        /// </summary>
        /// <returns>Último código da tabela Carro</returns>
        public int ultimoCodigoCarro()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Carro";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        if (drLer["vCodigo"].ToString().Length > 0)
                            iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (37)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        /// <summary>
        /// Função para ajustar dados na tabela de modelo
        /// </summary>
        /// <param name="cCarro">Objeto Carro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool ajustarModelo(carro cCarro)
        {
            bool bResposta = false;
            bool bExiste = false;
            string sSQL = "SELECT * FROM Modelo WHERE Modelo = @Modelo AND CodMarca = @CodMarca";
            int iTemp = 0;
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Modelo", cCarro.Modelo));
                cmComando.Parameters.Add(new SqlParameter("@CodMarca", cCarro.CodMarca));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read()) bExiste = true;
                }
                drLer.Close();
                cmComando.Dispose();

                if (!bExiste)
                {

                    sSQL = "INSERT INTO Modelo(CodMarca, Modelo, Portas, Motor) VALUES(@CodMarca, @Modelo, @Portas, @Motor)";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);                    
                    cmComando.Parameters.Add(new SqlParameter("@CodMarca", cCarro.CodMarca));
                    cmComando.Parameters.Add(new SqlParameter("@Modelo", cCarro.Modelo));
                    cmComando.Parameters.Add(new SqlParameter("@Portas", iTemp));
                    cmComando.Parameters.Add(new SqlParameter("@Motor", iTemp));
                    cmComando.ExecuteNonQuery();
                }
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de ajuste de Marca! " + ex.Message, "EstacionamentoFacil (38x)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para efetuar a atualização de dados de Carros
        /// </summary>
        /// <param name="cCarro">Objeto Carro</param>
        /// <param name="bTipo">Tipo de gravação 0 - Novo 1 - Atualização</param>
        /// <returns>Retorna T (verdadeiro) F (falso) ou o código do carro para tipo = 0</returns>
        public string inserirAtualizarCarro(carro cCarro, byte bTipo)
        {
            string sResposta = "F";
            string sSQL = "";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO Carro( " +
                               " CodMarca, Modelo, Serie, Placa, AnoFab, AnoMod, Cor, QtdePortas, Chassi, Renavan, Num_motor, Procedencia, Configuracao, Lugares, Transmissao, Tracao, Potencia, Rpm, Torque, Placa2, Chassi2, Situacao, Renavan2) VALUES(" +
                               "@CodMarca,@Modelo,@Serie,@Placa,@AnoFab,@AnoMod,@Cor,@QtdePortas,@Chassi,@Renavan,@Num_motor,@Procedencia,@Configuracao,@Lugares,@Transmissao,@Tracao,@Potencia,@Rpm,@Torque,@Placa2,@Chassi2,@Situacao,@Renavan2)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@CodMarca", cCarro.CodMarca));
                        cmComando.Parameters.Add(new SqlParameter("@Modelo", cCarro.Modelo));
                        cmComando.Parameters.Add(new SqlParameter("@Serie", cCarro.Serie));
                        cmComando.Parameters.Add(new SqlParameter("@Placa", cCarro.Placa));
                        cmComando.Parameters.Add(new SqlParameter("@AnoFab", cCarro.AnoFab));
                        cmComando.Parameters.Add(new SqlParameter("@AnoMod", cCarro.AnoMod));
                        cmComando.Parameters.Add(new SqlParameter("@Cor", cCarro.cor));
                        cmComando.Parameters.Add(new SqlParameter("@QtdePortas", cCarro.QtdePortas));
                        cmComando.Parameters.Add(new SqlParameter("@Chassi", cCarro.Chassi));
                        cmComando.Parameters.Add(new SqlParameter("@Renavan", cCarro.Renavan));
                        cmComando.Parameters.Add(new SqlParameter("@Num_motor", cCarro.Num_motor));
                        cmComando.Parameters.Add(new SqlParameter("@Procedencia", cCarro.Procedencia));
                        cmComando.Parameters.Add(new SqlParameter("@Configuracao", cCarro.Configuracao));
                        cmComando.Parameters.Add(new SqlParameter("@Lugares", cCarro.Lugares));
                        cmComando.Parameters.Add(new SqlParameter("@Transmissao", cCarro.Transmissao));
                        cmComando.Parameters.Add(new SqlParameter("@Tracao", cCarro.Tracao));
                        cmComando.Parameters.Add(new SqlParameter("@Potencia", cCarro.Potencia));
                        cmComando.Parameters.Add(new SqlParameter("@Rpm", cCarro.Rpm));
                        cmComando.Parameters.Add(new SqlParameter("@Torque", cCarro.Torque));
                        cmComando.Parameters.Add(new SqlParameter("@Placa2", cCarro.Placa2));
                        cmComando.Parameters.Add(new SqlParameter("@Chassi2", cCarro.Chassi2));
                        cmComando.Parameters.Add(new SqlParameter("@Situacao", cCarro.Situacao));
                        cmComando.Parameters.Add(new SqlParameter("@Renavan2", cCarro.Renavan2));
                        cmComando.ExecuteNonQuery();
                        cmComando.Dispose();

                        sSQL = "SELECT MAX(Codigo) vCodigo FROM Carro";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        drLer = cmComando.ExecuteReader();
                        if (drLer.HasRows)
                        {
                            if (drLer.Read())
                                sResposta = drLer["vCodigo"].ToString();
                        }
                        drLer.Dispose();
                        drLer.Close();
                        cmComando.Dispose();
                        break;
                    case 1:
                        //atualizar:
                        sSQL = "UPDATE Carro SET " +
                                  "CodMarca     = @CodMarca, " +
                                  "Modelo       = @Modelo, " +
                                  "Serie        = @Serie, " +
                                  "Placa        = @Placa, " +
                                  "AnoFab       = @AnoFab, " +
                                  "AnoMod       = @AnoMod, " +
                                  "Cor          = @Cor, " +
                                  "QtdePortas   = @QtdePortas, " +
                                  "Chassi       = @Chassi, " +
                                  "Renavan      = @Renavan, " +
                                  "Num_motor    = @Num_motor, " +
                                  "Procedencia  = @Procedencia, " +
                                  "Configuracao = @Configuracao, " +
                                  "Lugares      = @Lugares, " +
                                  "Transmissao  = @Transmissao, " +
                                  "Tracao       = @Tracao, " +
                                  "Potencia     = @Potencia, " +
                                  "Rpm          = @Rpm, " +
                                  "Torque       = @Torque, " +
                                  "Placa2       = @Placa2, " +
                                  "Chassi2      = @Chassi2, " +
                                  "Situacao     = @Situacao, " +
                                  "REnavan2     = @Renavan2 " +
                               "WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@CodMarca", cCarro.CodMarca));
                        cmComando.Parameters.Add(new SqlParameter("@Modelo", cCarro.Modelo));
                        cmComando.Parameters.Add(new SqlParameter("@Serie", cCarro.Serie));
                        cmComando.Parameters.Add(new SqlParameter("@Placa", cCarro.Placa));
                        cmComando.Parameters.Add(new SqlParameter("@AnoFab", cCarro.AnoFab));
                        cmComando.Parameters.Add(new SqlParameter("@AnoMod", cCarro.AnoMod));
                        cmComando.Parameters.Add(new SqlParameter("@Cor", cCarro.cor));
                        cmComando.Parameters.Add(new SqlParameter("@QtdePortas", cCarro.QtdePortas));
                        cmComando.Parameters.Add(new SqlParameter("@Chassi", cCarro.Chassi));
                        cmComando.Parameters.Add(new SqlParameter("@Renavan", cCarro.Renavan));
                        cmComando.Parameters.Add(new SqlParameter("@Num_motor", cCarro.Num_motor));
                        cmComando.Parameters.Add(new SqlParameter("@Procedencia", cCarro.Procedencia));
                        cmComando.Parameters.Add(new SqlParameter("@Configuracao", cCarro.Configuracao));
                        cmComando.Parameters.Add(new SqlParameter("@Lugares", cCarro.Lugares));
                        cmComando.Parameters.Add(new SqlParameter("@Transmissao", cCarro.Transmissao));
                        cmComando.Parameters.Add(new SqlParameter("@Tracao", cCarro.Tracao));
                        cmComando.Parameters.Add(new SqlParameter("@Potencia", cCarro.Potencia));
                        cmComando.Parameters.Add(new SqlParameter("@Rpm", cCarro.Rpm));
                        cmComando.Parameters.Add(new SqlParameter("@Torque", cCarro.Torque));
                        cmComando.Parameters.Add(new SqlParameter("@Placa2", cCarro.Placa2));
                        cmComando.Parameters.Add(new SqlParameter("@Chassi2", cCarro.Chassi2));
                        cmComando.Parameters.Add(new SqlParameter("@Situacao", cCarro.Situacao));
                        cmComando.Parameters.Add(new SqlParameter("@Renavan2", cCarro.Renavan2));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cCarro.Codigo));
                        cmComando.ExecuteNonQuery();
                        sResposta = "T";
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (38)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                sResposta = "F";
            }
            return sResposta;
        }

        /// <summary>
        /// Função para pesquisar dados de um determinado carro
        /// </summary>
        /// <param name="iCodigo">Código do carro a ser pesquisado</param>
        /// <returns>Retorna o objeto Carro com os dados preenchidos</returns>
        public carro pesquisaCarro(int iCodigo)
        {
            carro cCarro = new carro();
            string sSQL = "SELECT * FROM Carro WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cCarro.Codigo = int.Parse(drLer["Codigo"].ToString());
                        cCarro.CodMarca = int.Parse(drLer["CodMarca"].ToString());
                        cCarro.Modelo = drLer["Modelo"].ToString();
                        cCarro.Serie = drLer["Serie"].ToString();
                        cCarro.Placa = int.Parse(drLer["Placa"].ToString());
                        cCarro.AnoFab = int.Parse(drLer["AnoFab"].ToString());
                        cCarro.AnoMod = int.Parse(drLer["AnoMod"].ToString());
                        cCarro.cor = drLer["Cor"].ToString();
                        cCarro.QtdePortas = int.Parse(drLer["QtdePortas"].ToString());
                        cCarro.Chassi = int.Parse(drLer["Chassi"].ToString());
                        cCarro.Renavan = int.Parse(drLer["Renavan"].ToString());
                        cCarro.Num_motor = drLer["Num_motor"].ToString();
                        cCarro.Procedencia = int.Parse(drLer["Procedencia"].ToString());
                        cCarro.Configuracao = int.Parse(drLer["Configuracao"].ToString());
                        cCarro.Lugares = int.Parse(drLer["Lugares"].ToString());
                        cCarro.Transmissao = int.Parse(drLer["Transmissao"].ToString());
                        cCarro.Tracao = int.Parse(drLer["Tracao"].ToString());
                        cCarro.Potencia = int.Parse(drLer["Potencia"].ToString());
                        cCarro.Rpm = int.Parse(drLer["Rpm"].ToString());
                        cCarro.Torque = float.Parse(drLer["Torque"].ToString());
                        cCarro.Placa2 = drLer["Placa2"].ToString();
                        cCarro.Chassi2 = drLer["Chassi2"].ToString();
                        cCarro.Situacao = drLer["Situacao"].ToString();
                        cCarro.Renavan2 = drLer["Renavan2"].ToString();
                        return cCarro;
                    }
                    else
                        return null;
                }
                else
                    return null;
                drLer.Dispose();
                drLer.Close();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (39)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para retornar todos os carros cadastrados ordenado por placa
        /// </summary>
        /// <returns>Retorna DataReader contendo o resultado da pesquisa</returns>
        public SqlDataReader pesquisarTodosCarros()
        {
            string sSQL = "SELECT * FROM Carro ORDER BY Placa2";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (40)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os carros do cliente
        /// </summary>
        /// <param name="iCodigo">Código deo cliente para pesquisa</param>
        /// <returns>Retorna DataReader contendo o result da consulta</returns>
        public SqlDataReader pesquisarTodosCarrosCliente(int iCodigo)
        {
            string sSQL = "SELECT * FROM Carro WHERE codigo IN (SELECT codigocarro FROM ClienteCarro WHERE codigocliente = @Codigo) ORDER BY Placa2";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (40b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para alterar a situação do carro (Exclusão/Histórico)
        /// </summary>
        /// <param name="iCodigo">Código do carro para alteração</param>
        /// <param name="sSituacao">Situação para alteração (A - Ativo, E - Exclusão, H - Histórico</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool alterarSituacao(int iCodigo, string sSituacao)
        {
            bool bResposta = false;
            string sSQL = "UPDATE Carro SET Situacao = @Situacao WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Situacao", sSituacao));
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (41)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar se um carro existe
        /// </summary>
        /// <param name="sPlaca">Num. da placa do carro</param>
        /// <returns>Retorna verdadeiro caso exista o carro cadastrado</returns>
        public bool existeCarro(string sPlaca)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Carro WHERE Placa2 LIKE '%" + sPlaca +  "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0) bResposta = true;
                    }
                }
                drLer.Close();
                drLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (42)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar dados do modelo de carro
        /// </summary>
        /// <param name="cModelo">Objeto Modelo</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarModelo(modelo cModelo, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO modelo(CodMarca, Modelo, Portas, Motor) VALUES(@CodMarca,@Modelo,@Portas,@Motor)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@CodMarca", cModelo.codmarca));
                        cmComando.Parameters.Add(new SqlParameter("@Modelo", cModelo.Modelo));
                        cmComando.Parameters.Add(new SqlParameter("@Portas", cModelo.portas));
                        cmComando.Parameters.Add(new SqlParameter("@Motor", cModelo.motor));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        sSQL = "UPDATE modelo SET CodMarca = @CodMarca, Modelo = @Modelo, Portas = @Portas, Motor = @Motor WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@CodMarca", cModelo.codmarca));
                        cmComando.Parameters.Add(new SqlParameter("@Modelo", cModelo.Modelo));
                        cmComando.Parameters.Add(new SqlParameter("@Portas", cModelo.portas));
                        cmComando.Parameters.Add(new SqlParameter("@Motor", cModelo.motor));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cModelo.codigo));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (43)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar os dados de Modelo
        /// </summary>
        /// <param name="iCodigo">Código do Modelo para pesquisa</param>
        /// <returns>Objeto Modelo</returns>
        public modelo pesquisaModelo(int iCodigo)
        {
            modelo cModelo = new modelo();
            string sSQL = "SELECT * FROM modelo WHERE codigo = @codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cModelo.codigo = int.Parse(drLer["Codigo"].ToString());
                        cModelo.codmarca = int.Parse(drLer["CodMarca"].ToString());
                        cModelo.Modelo = drLer["Modelo"].ToString();
                        cModelo.portas = int.Parse(drLer["Portas"].ToString());
                        cModelo.motor = int.Parse(drLer["Motor"].ToString());
                        return cModelo;
                    }
                    else return null;
                }
                else return null;
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (44)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os registros de Modelos
        /// </summary>
        /// <returns>Retorna result da consulta</returns>
        public SqlDataReader pesquisarTodosModelos()
        {
            string sSQL = "SELECT * FROM Modelo ORDER BY Modelo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (45)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para verificar se modelo existe
        /// </summary>
        /// <param name="sModelo">Nome do Modelo</param>
        /// <returns>Retorna verdadeiro ou falso caso Modelo esteja cadastrado ou não</returns>
        public bool existeModelo(string sModelo)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Modelo WHERE Modelo LIKE '%" + sModelo + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0) bResposta = true;
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (46)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar dados do Opicionais de carro
        /// </summary>
        /// <param name="cOpicionais">Objeto Opicionais</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarOpicionais(opicionais cOpicionais, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO Opicionais(Codigo, Descricao) VALUES(@Codigo, @Descricao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cOpicionais.codigo));
                        cmComando.Parameters.Add(new SqlParameter("@Descricao", cOpicionais.descricao));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        sSQL = "UPDATE Opicionais SET Descricao = @Descricao WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Descricao", cOpicionais.descricao));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cOpicionais.codigo));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (47)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        public bool excluirOpcional(int iCodigoOpcional)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM opicionais WHERE codigo = @codigo";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigoOpcional));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Opcional");
                else
                    System.Windows.Forms.MessageBox.Show("Erro ao excluir Opcional! " + ex.Message, "EstacionamentoFacil (47b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar os dados de Opicionais
        /// </summary>
        /// <param name="iCodigo">Código de Opicionais para pesquisa</param>
        /// <returns>Objeto Opicionais</returns>
        public opicionais pesquisaOpicionais(int iCodigo)
        {
            opicionais cOpicionais = new opicionais();
            string sSQL = "SELECT * FROM opicionais WHERE codigo = @codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cOpicionais.codigo = int.Parse(drLer["Codigo"].ToString());
                        cOpicionais.descricao = drLer["Descricao"].ToString();
                        return cOpicionais;
                    }
                    else return null;
                }
                else return null;
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (48)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os registros de Opicionais
        /// </summary>
        /// <returns>Retorna result da consulta</returns>
        public SqlDataReader pesquisarTodosOpicionais()
        {
            string sSQL = "SELECT * FROM Opicionais ORDER BY Descricao";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (49)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Pesquisar todos os opcionais de um determinado carro
        /// </summary>
        /// <param name="iCodCarro">Código do carro para pesquisa</param>
        /// <returns>Retorna DataReader contendo a pesquisa realizada</returns>
        public SqlDataReader pesquisarTodosOpicionaisCarro(int iCodCarro)
        {
            string sSQL = "SELECT op.* FROM Opicionais op INNER JOIN Carro_Opcionais cop ON op.Codigo = cop.CodOpcionais WHERE cop.CodCarro = @CodCarro ORDER BY op.Descricao";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodCarro", iCodCarro));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (49b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Pesquisar todos os opcionais que não estão lançados em um determinado carro
        /// </summary>
        /// <param name="iCodCarro">Código do carro para pesquisa</param>
        /// <returns>Retorna DataReader contendo a pesquisa realizada</returns>
        public SqlDataReader pesquisarTodosOpicionaisNCarro(int iCodCarro)
        {
            string sSQL = "SELECT * FROM Opicionais WHERE Codigo NOT IN (SELECT CodOpcionais FROM Carro_Opcionais WHERE CodCarro = @CodCarro) ORDER BY Descricao";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodCarro", iCodCarro));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (49c)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para verificar se Opicinal existe
        /// </summary>
        /// <param name="sDescricao">Descricao do opicional</param>
        /// <returns>Retorna verdadeiro ou falso caso Modelo esteja cadastrado ou não</returns>
        public bool existeOpicional(string sDescricao)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Opicionais WHERE Descricao LIKE '%" + sDescricao + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0) bResposta = true;
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (50)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar o último código de opicionais
        /// </summary>
        /// <returns>Retorna inteiro contendo o último código da tabela Opicionais</returns>
        public int ultimoCodigoOpicionais()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Opicionais";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        if (drLer["vCodigo"].ToString().Length > 0)
                            iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (50b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        /// <summary>
        /// Função para gravar dados do Marca de carro
        /// </summary>
        /// <param name="cMarca">Objeto Marca</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarMarca(marca cMarca, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO Marca2(Codigo, Descricao) VALUES(@Codigo, @Descricao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cMarca.codigo));
                        cmComando.Parameters.Add(new SqlParameter("@Descricao", cMarca.descricao));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        sSQL = "UPDATE Marca2 SET Descricao = @Descricao WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Descricao", cMarca.descricao));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cMarca.codigo));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (51)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar os dados de Marca
        /// </summary>
        /// <param name="iCodigo">Código de Marca para pesquisa</param>
        /// <returns>Objeto Marca</returns>
        public marca pesquisaMarca(int iCodigo)
        {
            marca cMarca = new marca();
            string sSQL = "SELECT * FROM Marca2 WHERE codigo = @codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cMarca.codigo = int.Parse(drLer["Codigo"].ToString());
                        cMarca.descricao = drLer["Descricao"].ToString();
                        return cMarca;
                    }
                    else return null;
                }
                else return null;
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (52)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os registros de Marca
        /// </summary>
        /// <returns>Retorna result da consulta</returns>
        public SqlDataReader pesquisarTodasMarca()
        {
            string sSQL = "SELECT * FROM Marca2 ORDER BY Descricao";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (53)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para verificar se Marca existe
        /// </summary>
        /// <param name="sDescricao">Descricao da marca</param>
        /// <returns>Retorna verdadeiro ou falso caso Modelo esteja cadastrado ou não</returns>
        public bool existeMarca(string sDescricao)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Marca2 WHERE Descricao LIKE '%" + sDescricao + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0) bResposta = true;
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (54)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar último código de Marca
        /// </summary>
        /// <returns>Retorna inteiro com o último código de marca</returns>
        public int ultimoCodigoMarca()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(codigo) vCodigo FROM Marca2";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        if (drLer["vCodigo"].ToString().Length > 0)
                            iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (54b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        public bool excluirMarca(int iCodigo)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM Marca2 WHERE codigo = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Marca");
                else
                    System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (54c)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar dados da Despesas de carro
        /// </summary>
        /// <param name="cDespesas">Objeto Despesas</param>
        /// <param name="iCodigoCarro">Código do carro a ser inserido a despesa</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarDespesas(despesas cDespesas, int iCodigoCarro, byte bTipo)
        {
            bool bResposta = false;
            int iCodigoDespesa = 0;
            string sSQL = "";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO Despesas(Descrição, Num_nota, Data, Valor, Observacao) VALUES(@Descrição,@Num_nota,@Data,@Valor,@Observacao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Descrição", cDespesas.Descrição));
                        cmComando.Parameters.Add(new SqlParameter("@Num_nota", cDespesas.Num_nota));
                        cmComando.Parameters.Add(new SqlParameter("@Data", cDespesas.Data));
                        cmComando.Parameters.Add(new SqlParameter("@Valor", cDespesas.Valor));
                        cmComando.Parameters.Add(new SqlParameter("@Observacao", cDespesas.Observacao));
                        cmComando.ExecuteNonQuery();
                        cmComando.Dispose();

                        sSQL = "SELECT MAX(Codigo) vMax FROM Despesas";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        drLer = cmComando.ExecuteReader();
                        if (drLer.HasRows)
                        {
                            if (drLer.Read())
                            {
                                iCodigoDespesa = int.Parse(drLer["vMax"].ToString());
                            }
                        }
                        drLer.Dispose();
                        drLer.Close();
                        cmComando.Dispose();

                        if (iCodigoDespesa > 0)
                        {
                            sSQL = "INSERT INTO Despesas_carro(Cod_despesa, Cod_Carro) VALUES(@cod_despesa, @cod_carro)";
                            cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                            cmComando.Parameters.Add(new SqlParameter("@cod_despesa", iCodigoDespesa));
                            cmComando.Parameters.Add(new SqlParameter("@cod_carro", iCodigoCarro));
                            cmComando.ExecuteNonQuery();
                            cmComando.Dispose();
                        }

                        bResposta = true;
                        break;
                    case 1:
                        sSQL = "UPDATE Despesas SET Descrição = @Descrição, Num_nota = @Num_nota, Data = @Data, Valor = @Valor, Observacao = @Observacao WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Descrição", cDespesas.Descrição));
                        cmComando.Parameters.Add(new SqlParameter("@Num_nota", cDespesas.Num_nota));
                        cmComando.Parameters.Add(new SqlParameter("@Data", cDespesas.Data));
                        cmComando.Parameters.Add(new SqlParameter("@Valor", cDespesas.Valor));
                        cmComando.Parameters.Add(new SqlParameter("@Observacao", cDespesas.Observacao));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cDespesas.codigo));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (55)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retorar no valor total de despesas de um carro
        /// </summary>
        /// <param name="iCodigoCarro">Código de carro para a pesquisa</param>
        /// <returns>Retorna o valor da despesa</returns>
        public double pesquisaDespesaValorCarro(int iCodigoCarro)
        {
            double dResposta = 0;
            string sSQL = "SELECT SUM(Valor) AS vSoma FROM Despesas WHERE Codigo IN (SELECT Cod_despesa FROM Despesas_carro WHERE Cod_carro = @codigo)";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigoCarro));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        dResposta = double.Parse(drLer["vSoma"].ToString());
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (85)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return dResposta;
        }

        /// <summary>
        /// Função para retornar os dados de Despesas
        /// </summary>
        /// <param name="iCodigo">Código de Despesas para pesquisa</param>
        /// <returns>Objeto Despesa</returns>
        public despesas pesquisaDespesas(int iCodigo)
        {
            despesas cDespesas = new despesas();
            string sSQL = "SELECT * FROM Despesas WHERE codigo = @codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cDespesas.codigo = int.Parse(drLer["Codigo"].ToString());
                        cDespesas.Descrição = drLer["Descrição"].ToString();
                        cDespesas.Num_nota =int.Parse(drLer["Num_nota"].ToString());
                        cDespesas.Data = DateTime.Parse(drLer["Data"].ToString());
                        cDespesas.Valor = double.Parse(drLer["Valor"].ToString());
                        cDespesas.Observacao = drLer["Observacao"].ToString();
                        return cDespesas;
                    }
                    else return null;
                }
                else return null;
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (56)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os registros de Despesas
        /// </summary>
        /// <returns>Retorna result da consulta</returns>
        public SqlDataReader pesquisarTodasDespesas()
        {
            string sSQL = "SELECT * FROM Despesas ORDER BY Descrição";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (57)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para verificar se Despesa existe
        /// </summary>
        /// <param name="sDescricao">Descricao da despesa</param>
        /// <returns>Retorna verdadeiro ou falso caso Despesa esteja cadastrado ou não</returns>
        public bool existeDespesa(string sDescricao)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Despesas WHERE Descrição LIKE '%" + sDescricao + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0) bResposta = true;
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (58)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar dados da Movimento de carro
        /// </summary>
        /// <param name="cMovimento">Objeto Movimento</param>
        /// <param name="bTipo">Tipo de gravação 0 - Inserir, 1 - Atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarMovimento(movimento cMovimento, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO Movimento(" +
                                    " CodCarro, CodCliente, DataMoviment, CodVendedor, Valor, TipoComissao, ValorComissao, LucroLiquido, Dut, Recibo, TipoComissao2, ValorComissao2) VALUES(" +
                                    "@CodCarro,@CodCliente,@DataMoviment,@CodVendedor,@Valor,@TipoComissao,@ValorComissao,@LucroLiquido,@Dut,@Recibo,@TipoComissao2,@ValorComissao2)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@CodCarro", cMovimento.codcarro));
                        cmComando.Parameters.Add(new SqlParameter("@CodCliente", cMovimento.codcliente));
                        cmComando.Parameters.Add(new SqlParameter("@DataMoviment", cMovimento.datamoviment));
                        cmComando.Parameters.Add(new SqlParameter("@CodVendedor", cMovimento.codvendedor));
                        cmComando.Parameters.Add(new SqlParameter("@Valor", cMovimento.valor));
                        cmComando.Parameters.Add(new SqlParameter("@TipoComissao", cMovimento.tipocomissao));
                        cmComando.Parameters.Add(new SqlParameter("@ValorComissao", cMovimento.valorcomissao));
                        cmComando.Parameters.Add(new SqlParameter("@LucroLiquido", cMovimento.lucroliquido));
                        cmComando.Parameters.Add(new SqlParameter("@Dut", cMovimento.dut));
                        cmComando.Parameters.Add(new SqlParameter("@Recibo", cMovimento.recibo));
                        cmComando.Parameters.Add(new SqlParameter("@TipoComissao2", cMovimento.TipoComissao2));
                        cmComando.Parameters.Add(new SqlParameter("@ValorComissao2", cMovimento.valorcomissao2));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        sSQL = "UPDATE Movimento SET " +
                                    "CodCarro       = @CodCarro, " +
                                    "CodCliente     = @CodCliente, " +
                                    "DataMoviment   = @DataMoviment, " +
                                    "CodVendedor    = @CodVendedor, " +
                                    "Valor          = @Valor, " +
                                    "TipoComissao   = @TipoComissao, " +
                                    "ValorComissao  = @ValorComissao, " +
                                    "LucroLiquido   = @LucroLiquido, " +
                                    "Dut            = @Dut, " +
                                    "Recibo         = @Recibo, " +
                                    "TipoComissao2  = @TipoComissao2, " +
                                    "ValorComissao2 = @ValorComissao2 " +
                               "WHERE Codigo = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@CodCarro", cMovimento.codcarro));
                        cmComando.Parameters.Add(new SqlParameter("@CodCliente", cMovimento.codcliente));
                        cmComando.Parameters.Add(new SqlParameter("@DataMoviment", cMovimento.datamoviment));
                        cmComando.Parameters.Add(new SqlParameter("@CodVendedor", cMovimento.codvendedor));
                        cmComando.Parameters.Add(new SqlParameter("@Valor", cMovimento.valor));
                        cmComando.Parameters.Add(new SqlParameter("@TipoComissao", cMovimento.tipocomissao));
                        cmComando.Parameters.Add(new SqlParameter("@ValorComissao", cMovimento.valorcomissao));
                        cmComando.Parameters.Add(new SqlParameter("@LucroLiquido", cMovimento.lucroliquido));
                        cmComando.Parameters.Add(new SqlParameter("@Dut", cMovimento.dut));
                        cmComando.Parameters.Add(new SqlParameter("@Recibo", cMovimento.recibo));
                        cmComando.Parameters.Add(new SqlParameter("@TipoComissao2", cMovimento.TipoComissao2));
                        cmComando.Parameters.Add(new SqlParameter("@ValorComissao2", cMovimento.valorcomissao2));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cMovimento.codigo));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (59)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar os dados de Movimento específico
        /// </summary>
        /// <param name="iCodigo">Código de Movimento para pesquisa</param>
        /// <returns>Objeto Movimento</returns>
        public movimento pesquisaMovimento(int iCodigo)
        {
            movimento cMovimento = new movimento();
            string sSQL = "SELECT * FROM Movimento WHERE codigo = @codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cMovimento.codigo = int.Parse(drLer["Codigo"].ToString());
                        cMovimento.codcarro = int.Parse(drLer["CodCarro"].ToString());
                        cMovimento.codcliente = int.Parse(drLer["CodCliente"].ToString());
                        cMovimento.datamoviment = DateTime.Parse(drLer["DataMoviment"].ToString());
                        cMovimento.codvendedor = int.Parse(drLer["CodVendedor"].ToString());
                        cMovimento.valor = double.Parse(drLer["Valor"].ToString());
                        cMovimento.tipocomissao = double.Parse(drLer["TipoComissao"].ToString());
                        cMovimento.valorcomissao = drLer["ValorComissao"].ToString();
                        cMovimento.lucroliquido = double.Parse(drLer["LucroLiquido"].ToString());
                        cMovimento.dut = drLer["Dut"].ToString();
                        cMovimento.recibo = drLer["Recibo"].ToString();
                        cMovimento.TipoComissao2 = drLer["TipoComissao2"].ToString();
                        cMovimento.valorcomissao2 = double.Parse(drLer["ValorComissao2"].ToString());

                        return cMovimento;
                    }
                    else return null;
                }
                else return null;
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (60)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os registros de Movimentos por carro
        /// </summary>
        /// <param name="iCodCarro">Codigo do carro para a pesquisa de movimento</param>
        /// <returns>Retorna result da consulta</returns>
        public SqlDataReader pesquisarTodosMovimentosPorCarro(int iCodCarro)
        {
            string sSQL = "SELECT * FROM Movimento WHERE CodCarro = @CodCarro ORDER BY DataMoviment";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodCarro", iCodCarro));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (61)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar todos os registros de Movimentos por cliente
        /// </summary>
        /// <param name="iCodCliente">Código do cliente para a pesquisa de movimento</param>
        /// <returns>Retorna result da consulta</returns>
        public SqlDataReader pesquisarTodosMovimentosPorCliente(int iCodCliente)
        {
            string sSQL = "SELECT * FROM Movimento WHERE CodCliente = @CodCliente ORDER BY DataMoviment";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodCliente", iCodCliente));
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (62)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisar os telefones do vendedor
        /// </summary>
        /// <param name="iCodigo">Código do vendedor</param>
        /// <returns>Lista de telefones</returns>
        public List<Telefones> pesquisaTelefoneVendedor(int iCodigo)
        {
            List<Telefones> lstTelefone = new List<Telefones>();
            string sSQL = "SELECT t.* FROM telefone t INNER JOIN TelefonesVendedor tc ON tc.CodigoTelefone = t.codtelefone WHERE tc.CodigoVendedor = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    while (drLer.Read())
                    {
                        lstTelefone.Add(new Telefones()
                        {
                            CodigoTelefone = int.Parse(drLer["codtelefone"].ToString()),
                            codoperadora = int.Parse(drLer["codoperadora"].ToString()),
                            ddd = drLer["ddd"].ToString(),
                            telefone = drLer["telefone"].ToString(),
                            tipotelefone = int.Parse(drLer["tipotelefone"].ToString())
                        });
                    }
                    return lstTelefone;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (64)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para excluir o telefone e o relacionamento com o vendedor
        /// </summary>
        /// <param name="iCodigo">Código do telefone para ser excluído</param>
        /// <returns>Retorna verdadeiro ou falso na execução da função</returns>
        public bool excluirTelefoneVendedor(int iCodigo)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM TelefonesVendedor WHERE CodigoTelefone = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "DELETE FROM Telefone WHERE codtelefone = @Codigo";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (65)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Exclusão de todos os telefones cadastrados de vendedor
        /// </summary>
        /// <param name="iCodigoVendedor">Código do vendedor para exclusão dos telefones</param>
        /// <returns>Verdadeiro ou falso dependendo da execução da função</returns>
        public bool excluirTodosTelefoneVendedor(int iCodigoVendedor)
        {
            bool bResposta = true;
            string sSQL = "DELETE FROM TelefonesVendedor WHERE CodigoVendedor = @Codigo";

            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigoVendedor));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "DELETE FROM Telefone WHERE codtelefone NOT IN (SELECT CodigoTelefone FROM TelefonesVendedor) AND telefonedq = 1";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (66)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o último código da tabela vendedor
        /// </summary>
        /// <returns>Último código da tabela Vendedor</returns>
        public int ultimoCodigoVendedor()
        {
            int iResposta = 0;
            string sSQL = "SELECT MAX(código) vCodigo FROM Vendedor";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                        if (drLer["vCodigo"].ToString().Length > 0)
                            iResposta = int.Parse(drLer["vCodigo"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (67)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return iResposta;
        }

        /// <summary>
        /// Função para efetuar a atualização de dados de vendedor
        /// </summary>
        /// <param name="cVendedor">Objeto vendedor</param>
        /// <param name="bTipo">Tipo de gravação 0 - Novo 1 - Atualização</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public string inserirAtualizarVendedor(vendedor cVendedor, byte bTipo)
        {
            string sResposta = "E";
            string sSQL = "";
            SqlCommand cmComando;
            string sTemp = "";
            try
            {
                switch (bTipo)
                {
                    case 0:                        
                        sSQL = "INSERT INTO Vendedor( " +
                               " Nome, CPF, Telefone, Celular, Email, Login, Senha, Lembrete, Situacao) VALUES(" +
                               "@Nome,@CPF,@Telefone,@Celular,@Email,@Login,@Senha,@Lembrete,@Situacao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Nome", cVendedor.nome));
                        cmComando.Parameters.Add(new SqlParameter("@CPF", cVendedor.cpf));
                        cmComando.Parameters.Add(new SqlParameter("@Telefone", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Celular", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Email", cVendedor.email));
                        cmComando.Parameters.Add(new SqlParameter("@Login", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Senha", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Lembrete", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Situacao", cVendedor.situacao));
                        cmComando.ExecuteNonQuery();
                        cmComando.Dispose();

                        sSQL = "SELECT MAX(Código) vCodigo FROM Vendedor";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        SqlDataReader drLer = cmComando.ExecuteReader();
                        if (drLer.HasRows)
                        {
                            if (drLer.Read())
                                sResposta = drLer["vCodigo"].ToString();
                        }
                        drLer.Dispose();
                        drLer.Close();
                        cmComando.Dispose();
                        break;
                    case 1:
                        //atualizar:
                        sSQL = "UPDATE Vendedor SET " +
                                  "Nome     = @Nome, " +
                                  "CPF      = @CPF, " +
                                  "Telefone = @Telefone, " +
                                  "Celular  = @Celular, " +
                                  "Email    = @Email, " +
                                  "Login    = @Login, " +
                                  "Senha    = @Senha, " +
                                  "Lembrete = @Lembrete, " +
                                  "Situacao = @Situacao " +
                               "WHERE Código = @Codigo";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@Nome", cVendedor.nome));
                        cmComando.Parameters.Add(new SqlParameter("@CPF", cVendedor.cpf));
                        cmComando.Parameters.Add(new SqlParameter("@Telefone", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Celular", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Email", cVendedor.email));
                        cmComando.Parameters.Add(new SqlParameter("@Login", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Senha", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Lembrete", sTemp));
                        cmComando.Parameters.Add(new SqlParameter("@Situacao", cVendedor.situacao));
                        cmComando.Parameters.Add(new SqlParameter("@Codigo", cVendedor.código));
                        cmComando.ExecuteNonQuery();
                        sResposta = "T";
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (68)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                
            }
            return sResposta;
        }

        /// <summary>
        /// Função para pesquisar os vendedores presente em uma venda
        /// </summary>
        /// <param name="cVendas">Objeto Vendas</param>
        /// <returns>Retorna uma lista com os objetos Vendedores</returns>
        public List<vendedor> pesquisarVendedorVenda(vendas cVendas)
        {
            List<vendedor> lstVendedor = null;
            string sSQL = "SELECT * FROM Vendedor WHERE Código IN (SELECT cod_vendedor FROM vendas_vendedor WHERE cod_venda = @cod_venda)";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL,conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_venda", cVendas.cod_venda));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstVendedor = new List<vendedor>();
                    while (drLer.Read())
                    {
                        lstVendedor.Add(new vendedor() { 
                            código = int.Parse(drLer["Código"].ToString()),
                            nome = drLer["Nome"].ToString(),
                            cpf = drLer["CPF"].ToString(),
                            telefone = drLer["Telefone"].ToString(),
                            celular = drLer["Celular"].ToString(),
                            email = drLer["Email"].ToString(),
                            login = drLer["Login"].ToString(),
                            senha = drLer["Senha"].ToString(),
                            lembrete = drLer["Lembrete"].ToString(),
                            situacao = drLer["Situacao"].ToString()
                        });                        
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (84)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstVendedor;
        }

        /// <summary>
        /// Função para pesquisar todos vendedores
        /// </summary>        
        /// <param name="sSituacao">Situacao A - Ativo, E - Excluido, I - Inativo, X - Todos</param>
        /// <returns>Retorna a lista de Vendedores</returns>
        public List<vendedor> pesquisarTodosVendedores(string sSituacao)
        {
            List<vendedor> lstVendedor = null;
            string situacaoVendedor = "";
            switch (sSituacao)
            {
                case "A":
                    situacaoVendedor = " WHERE Situacao = 'A'";
                    break;
                case "E":
                    situacaoVendedor = " WHERE Situacao = 'E'";
                    break;
                case "I":
                    situacaoVendedor = " WHERE Situacao = 'I'";
                    break;
            }

            string sSQL = "SELECT * FROM Vendedor" + situacaoVendedor + " ORDER BY Nome";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);                
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstVendedor = new List<vendedor>();
                    while (drLer.Read())
                    {
                        lstVendedor.Add(new vendedor()
                        {
                            código = int.Parse(drLer["Código"].ToString()),
                            nome = drLer["Nome"].ToString(),
                            cpf = drLer["CPF"].ToString(),
                            telefone = drLer["Telefone"].ToString(),
                            celular = drLer["Celular"].ToString(),
                            email = drLer["Email"].ToString(),
                            login = drLer["Login"].ToString(),
                            senha = drLer["Senha"].ToString(),
                            lembrete = drLer["Lembrete"].ToString(),
                            situacao = drLer["Situacao"].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (85)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstVendedor;
        }

        /// <summary>
        /// Função para pesquisar todos os telefones de um vendedor
        /// </summary>
        /// <param name="cVendedor">Objeto vendedor</param>
        /// <returns>Retorna uma lista com os telefones do vendedor</returns>
        public List<Telefones> pesquisarTodosTelefonesVendedor(vendedor cVendedor)
        {
            List<Telefones> lstTelefone = null;
            string sSQL = "SELECT t.* FROM telefone t INNER JOIN TelefonesVendedor tc ON tc.CodigoTelefone = t.codtelefone WHERE tc.CodigoVendedor = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", cVendedor.código));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstTelefone = new List<Telefones>();
                    while (drLer.Read())
                    {
                        lstTelefone.Add(new Telefones()
                        {
                            CodigoTelefone = int.Parse(drLer["codtelefone"].ToString()),
                            codoperadora = int.Parse(drLer["codoperadora"].ToString()),
                            ddd = drLer["ddd"].ToString(),
                            telefone = drLer["telefone"].ToString(),
                            tipotelefone = int.Parse(drLer["tipotelefone"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de consulta! " + ex.Message, "EstacionamentoFacil (86)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstTelefone;
        }

        /// <summary>
        /// Função para pesquisar todas as vendas de um vendedor
        /// </summary>
        /// <param name="cVendedor">Objeto vendedor</param>
        /// <returns>Retorna uma lista com as vendas do vendedor</returns>
        public List<vendas> pesquisarTodasVendasVendedor(vendedor cVendedor)
        {
            List<vendas> lstVendas = null;
            string sSQL = "SELECT * FROM Vendas WHERE cod_venda IN (SELECT cod_venda FROM vendas_vendedor WHERE cod_vendedor = @Codigo) ORDER BY data_venda DESC";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", cVendedor.código));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstVendas = new List<vendas>();
                    while (drLer.Read())
                    {
                        lstVendas.Add(new vendas()
                        {
                            cod_carro = int.Parse(drLer["cod_carro"].ToString()),
                            cod_cliente_comprador = int.Parse(drLer["cod_cliente_comprador"].ToString()),
                            cod_cliente_vendedor = int.Parse(drLer["cod_cliente_vendedor"].ToString()),
                            cod_venda = int.Parse(drLer["cod_venda"].ToString()),
                            data_venda = DateTime.Parse(drLer["data_venda"].ToString()),
                            tipo_comissao = drLer["tipo_comissao"].ToString().Trim(),
                            tipo_venda = int.Parse(drLer["tipo_venda"].ToString()),
                            valor = double.Parse(drLer["valor"].ToString()),
                            valor_comissao = double.Parse(drLer["valor_comissao"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de consulta! " + ex.Message, "EstacionamentoFacil (87)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstVendas;
        }

        /// <summary>
        /// Função para pesquisar dados de um determinado vendedor
        /// </summary>
        /// <param name="iCodigo">Código do vendedor a ser pesquisado</param>
        /// <returns>Retorna o objeto Carro com os dados preenchidos</returns>
        public vendedor pesquisaVendedor(int iCodigo)
        {
            vendedor cVendedor = new vendedor();
            string sSQL = "SELECT * FROM Vendedor WHERE Código = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        cVendedor.código = int.Parse(drLer["Código"].ToString());
                        cVendedor.nome = drLer["Nome"].ToString();
                        cVendedor.cpf = drLer["CPF"].ToString();
                        cVendedor.telefone = drLer["Telefone"].ToString();
                        cVendedor.celular = drLer["Celular"].ToString();
                        cVendedor.email = drLer["Email"].ToString();
                        cVendedor.login = drLer["Login"].ToString();
                        cVendedor.senha = drLer["Senha"].ToString();
                        cVendedor.lembrete = drLer["Lembrete"].ToString();
                        cVendedor.situacao = drLer["Situacao"].ToString();
                        return cVendedor;
                    }
                    else
                        return null;
                }
                else
                    return null;
                drLer.Dispose();
                drLer.Close();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (69)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para retornar todos os vendedores Ativos cadastrados ordenado por nome
        /// </summary>
        /// <returns>Retorna DataReader contendo o resultado da pesquisa</returns>
        public SqlDataReader pesquisarTodosVendedoresAtivos()
        {
            string sSQL = "SELECT * FROM Vendedor WHERE Situacao = 'A' ORDER BY Nome";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (70a)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para retornar todos os vendedores cadastrados ordenado por nome
        /// </summary>
        /// <returns>Retorna DataReader contendo o resultado da pesquisa</returns>
        public SqlDataReader pesquisarTodosVendedores()
        {
            string sSQL = "SELECT * FROM Vendedor ORDER BY Nome";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                return drLer;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (70b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para alterar a situação do vendedor (Ativo/Excluído/Inativo)
        /// </summary>
        /// <param name="iCodigo">Código do carro para alteração</param>
        /// <param name="sSituacao">Situação para alteração (A - Ativo, E - Exclusão, I - Invativo</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool alterarSituacaoVendedor(int iCodigo, string sSituacao)
        {
            bool bResposta = false;
            string sSQL = "UPDATE Vendedor SET Situacao = @Situacao WHERE Codigo = @Codigo";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@Situacao", sSituacao));
                cmComando.Parameters.Add(new SqlParameter("@Codigo", iCodigo));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (71)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para verificar se um vendedor existe
        /// </summary>
        /// <param name="sNome">Nome do vendedor para a pesquisa</param>
        /// <returns>Retorna verdadeiro caso exista o Vendedor cadastrado</returns>
        public bool existeVendedor(string sNome)
        {
            bool bResposta = false;
            string sSQL = "SELECT * FROM Vendedor WHERE Nome LIKE '%" + sNome + "%'";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                SqlDataReader drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (drLer["Codigo"].ToString().Length > 0) bResposta = true;
                    }
                }
                drLer.Close();
                drLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de pesquisa! " + ex.Message, "EstacionamentoFacil (72)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir o relacionamento de opcionais de um carro
        /// </summary>
        /// <param name="iCodigo">Código do opcional a ser excluido</param>
        /// <param name="bTipo">Tipo 0 - Codigo Opcional 1 - Codigo carro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função.</returns>
        public bool excluirOpcionalCarro(int iCodigo, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            switch (bTipo)
            {
                case 0:
                    sSQL = "DELETE FROM Carro_Opcionais WHERE CodOpcionais = " + iCodigo.ToString();
                    break;
                case 1:
                    sSQL = "DELETE FROM Carro_Opcionais WHERE CodCarro = " + iCodigo.ToString();
                    break;
            }
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão de opcional de carro! " + ex.Message, "EstacionamentoFacil (73)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravar relacionamento de opcionais de carro
        /// </summary>
        /// <param name="cOpcionais">Objeto opcional</param>
        /// <param name="cCarro">Objeto Carro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool gravarOpcionalCarro(opicionais cOpcionais, carro cCarro)
        {
            bool bResposta = false;
            string sSQL = "INSERT INTO Carro_Opcionais(CodCarro, CodOpcionais) VALUES(@CodCarro, @CodOpcionais)";
            try
            {
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodCarro", cCarro.Codigo));
                cmComando.Parameters.Add(new SqlParameter("@CodOpcionais", cOpcionais.codigo));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de inclusão de opcional de carro! " + ex.Message, "EstacionamentoFacil (74)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar uma lista de Despesas do Carro
        /// </summary>
        /// <param name="cCarro">Objeto Carro</param>
        /// <returns>Retorna uma lista de despesas de Carro</returns>
        public List<despesas> buscaDespesasCarro(carro cCarro)
        {
            List<despesas> lstDespesas = null;
            string sSQL = "SELECT * FROM Despesas WHERE Codigo IN (SELECT Cod_despesa FROM Despesas_carro WHERE Cod_carro = @CodCarro) ORDER BY Data DESC";
            try
            {
                SqlDataReader drLer;
                SqlCommand cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodCarro", cCarro.Codigo));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstDespesas = new List<despesas>();
                    while (drLer.Read())
                    {
                        lstDespesas.Add(new despesas()
                        {
                            codigo = int.Parse(drLer["codigo"].ToString()),
                            Descrição = drLer["Descrição"].ToString(),
                            Data = DateTime.Parse(drLer["Data"].ToString()),
                            Num_nota = int.Parse(drLer["Num_nota"].ToString()),
                            Observacao = drLer["Observacao"].ToString(),
                            Valor = double.Parse(drLer["Valor"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao pesquisar despesas de carro! " + ex.Message, "EstacionamentoFacil (75)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstDespesas;
        }
                
        /// <summary>
        /// Função para inserir/atualizar dados de histórico
        /// </summary>
        /// <param name="cHistorico">Objeto Historico</param>
        /// <param name="bTipo">Tipo 0 inserir 1 atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarHistorico(historico cHistorico, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO historico(cod_carro, cod_usuario, tipo, data_hist, observacao) VALUES(@cod_carro,@cod_usuario,@tipo,@data_hist,@observacao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@cod_carro", cHistorico.cod_carro));
                        cmComando.Parameters.Add(new SqlParameter("@cod_usuario", cHistorico.cod_usuario));
                        cmComando.Parameters.Add(new SqlParameter("@tipo", cHistorico.tipo));
                        cmComando.Parameters.Add(new SqlParameter("@data_hist", cHistorico.data_hist));
                        cmComando.Parameters.Add(new SqlParameter("@observacao", cHistorico.observacao));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        sSQL = "UPDATE historico SET cod_carro = @cod_carro, cod_usuario = @cod_usuario, tipo = @tipo, data_hist = @data_hist, observacao = @observacao WHERE cod_historico = @cod_historico";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@cod_carro", cHistorico.cod_carro));
                        cmComando.Parameters.Add(new SqlParameter("@cod_usuario", cHistorico.cod_usuario));
                        cmComando.Parameters.Add(new SqlParameter("@tipo", cHistorico.tipo));
                        cmComando.Parameters.Add(new SqlParameter("@data_hist", cHistorico.data_hist));
                        cmComando.Parameters.Add(new SqlParameter("@observacao", cHistorico.observacao));
                        cmComando.Parameters.Add(new SqlParameter("@cod_historico", cHistorico.cod_historico));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de cadastro! " + ex.Message, "EstacionamentoFacil (76)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }
       

        /// <summary>
        /// Função para consultar dados de histórico
        /// </summary>
        /// <param name="iCodigo">Código para consulta, mediante o tipo. Tipo 0 - Código de histórico, Tipo 1 - Código de carro, Tipo 2 - Código de usuário</param>
        /// <param name="bTipo">Tipo 0 Consulta de um único histórico, 1 Histórico para um carro, 2 Histórico para um usuário</param>
        /// <returns></returns>
        public List<historico> consultarHistorico(int iCodigo, byte bTipo)
        {
            List<historico> lstHitorico = null;
            string sSQL = "";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "SELECT * FROM Historico WHERE cod_historico = @codigo";            
                        break;
                    case 1:
                        sSQL = "SELECT * FROM Historico WHERE     cod_carro = @codigo ORDER BY data_hist DESC";                        
                        break;
                    case 2:
                        sSQL = "SELECT * FROM Historico WHERE   cod_usuario = @codigo ORDER BY data_hist DESC";
                        break;
                }//switch

                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstHitorico = new List<historico>();
                    while (drLer.Read())
                    {
                        lstHitorico.Add(new historico()
                        {
                            cod_historico = int.Parse(drLer["cod_historico"].ToString()),
                            cod_carro = int.Parse(drLer["cod_carro"].ToString()),
                            cod_usuario = int.Parse(drLer["cod_usuario"].ToString()),
                            tipo = int.Parse(drLer["tipo"].ToString()),
                            data_hist = DateTime.Parse(drLer["data_hist"].ToString()),
                            observacao = drLer["observacao"].ToString()
                        });
                    }
                }
                drLer.Dispose();
                drLer.Close();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de consulta! " + ex.Message, "EstacionamentoFacil (77)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return lstHitorico;
        }

        /// <summary>
        /// Função para exclusão de dados de despesa de carro
        /// </summary>
        /// <param name="iCodigoDespesa">Código da despesa para exclusão</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirDespesa(int iCodigoDespesa)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM Despesas_carro WHERE Cod_despesa = @codigo";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigoDespesa));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "DELETE FROM despesas WHERE Codigo = @codigo";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigoDespesa));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                bResposta = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Despesa");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (84)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir um cadastro de histórico
        /// </summary>
        /// <param name="iCodigoHistorico">Código do histórico a ser excluido</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirHistorico(int iCodigoHistorico)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM historico WHERE cod_historico = @cod_historico";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_historico", iCodigoHistorico));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Histórico");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao executar comando de exclusão! " + ex.Message, "EstacionamentoFacil (78)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gravação de dados de auditoria
        /// </summary>
        /// <param name="iOperacao">Operação de auditoria</param>
        /// <param name="iCodUsuario">Código do usuário</param>
        /// <param name="sDescritivo">Algum descritivo para a gravação</param>
        /// <param name="sTela">Tela de execução</param>
        public void inserirAuditoria(int iOperacao, int iCodUsuario, string sDescritivo, string sTela)
        {
            /*
            string sSQL = "INSERT INTO auditoria(operacao, cod_usuario, data_operacao, descritivo, tela) VALUES(@operacao, @cod_usuario, @data_operacao, @descritivo, @tela)";
            SqlCommand cmComando;
            DateTime dtDataAtual = DateTime.Now;
            try
            {
                if(sDescritivo.Trim().Length == 0) sDescritivo = " ";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@operacao", iOperacao));
                cmComando.Parameters.Add(new SqlParameter("@cod_usuario", iCodUsuario));
                cmComando.Parameters.Add(new SqlParameter("@data_operacao", dtDataAtual.ToString("dd/MM/yyyy HH:mm:ss")));
                cmComando.Parameters.Add(new SqlParameter("@descritivo", sDescritivo));
                cmComando.Parameters.Add(new SqlParameter("@tela", sTela));                
                cmComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao executar auditoria! " + ex.Message, "EstacionamentoFacil (79)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
             * */
        }

        /// <summary>
        /// Função para pesquisar dados de observação
        /// </summary>
        /// <param name="bTipo">Tipo da pesquisa 0 Carro, 1 Cliente, 2 Vendas</param>
        /// <param name="iCodigo">Código de vínculo para pesquisa</param>
        /// <returns>Retorna uma lista contendo as observações pesquisadas</returns>
        public List<observacao> buscaObservacao(byte bTipo, int iCodigo)
        {
            List<observacao> lstObservacao = null;
            string sSQL = "";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {                
                sSQL = "SELECT * FROM observacao WHERE tipo = @tipo AND codigo = @codigo ORDER BY data_observacao DESC";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@tipo", bTipo));
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstObservacao = new List<observacao>();
                    while (drLer.Read())
                    {
                        lstObservacao.Add(new observacao()
                        {
                            cod_observacao = int.Parse(drLer["cod_observacao"].ToString()),
                            tipo = int.Parse(drLer["tipo"].ToString()),
                            sObservacao = drLer["observacao"].ToString(),
                            data_observacao = DateTime.Parse(drLer["data_observacao"].ToString()),
                            cod_usuario = int.Parse(drLer["cod_usuario"].ToString()),
                            codigo = int.Parse(drLer["codigo"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao pesquisar observação! " + ex.Message, "EstacionamentoFacil (80)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstObservacao;
        }

        /// <summary>
        /// Função para inserir dados em Observação
        /// </summary>
        /// <param name="cObservacao">Objeto Observação preenchido</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirObservacao(observacao cObservacao)
        {
            bool bResposta = false;
            string sSQL = "INSERT INTO observacao(tipo, observacao, data_observacao, cod_usuario, codigo) VALUES(@tipo, @observacao, @data_observacao, @cod_usuario, @codigo)";
            SqlCommand cmComando;
            DateTime dtDataAtual = DateTime.Now;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@tipo", cObservacao.tipo));
                cmComando.Parameters.Add(new SqlParameter("@observacao", cObservacao.sObservacao));
                cmComando.Parameters.Add(new SqlParameter("@data_observacao", cObservacao.data_observacao.ToString("dd/MM/yyyy HH:mm:ss")));
                cmComando.Parameters.Add(new SqlParameter("@cod_usuario", cObservacao.cod_usuario));
                cmComando.Parameters.Add(new SqlParameter("@codigo", cObservacao.codigo));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao inserir nova observação! " + ex.Message, "EstacionamentoFacil (81)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para inserir dados em conta/cartão
        /// </summary>
        /// <param name="cContaCartao">Objeto contacartao preenchido</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirContaCartaoCliente(ContaCartaoCliente cContaCartao)
        {
            bool bResposta = false;
            string sSQL = "INSERT INTO ContaCartao(CodCliente, Tipo, Numero, Bandeira, NomeBanco, Agencia, NumConta, CPF, CNPJ, OBS) VALUES(@CodCliente,@Tipo,@Numero,@Bandeira,@NomeBanco,@Agencia,@NumConta,@CPF,@CNPJ,@OBS)";
            SqlCommand cmComando;            
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@CodCliente", cContaCartao.CodCliente));
                cmComando.Parameters.Add(new SqlParameter("@Tipo", cContaCartao.Tipo));
                cmComando.Parameters.Add(new SqlParameter("@Numero", cContaCartao.Numero));
                cmComando.Parameters.Add(new SqlParameter("@Bandeira", cContaCartao.Bandeira));
                cmComando.Parameters.Add(new SqlParameter("@NomeBanco", cContaCartao.NomeBanco));
                cmComando.Parameters.Add(new SqlParameter("@Agencia", cContaCartao.Agencia));
                cmComando.Parameters.Add(new SqlParameter("@NumConta", cContaCartao.NumConta));
                cmComando.Parameters.Add(new SqlParameter("@CPF", cContaCartao.CPF));
                cmComando.Parameters.Add(new SqlParameter("@CNPJ", cContaCartao.CNPJ));
                cmComando.Parameters.Add(new SqlParameter("@OBS", cContaCartao.Obs));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao inserir nova conta/cartão! " + ex.Message, "EstacionamentoFacil (200)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para exclusão da observação
        /// </summary>
        /// <param name="iCodigoObservacao">Código da observação a ser excluída</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirObservacao(int iCodigoObservacao)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM observacao WHERE cod_observacao = @cod_observacao";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_observacao", iCodigoObservacao));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("Observação");
                else
                System.Windows.Forms.MessageBox.Show("Erro ao excluir observação! " + ex.Message, "EstacionamentoFacil (82)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para exclusão da conta/catão
        /// </summary>
        /// <param name="iCodigoContaCartao">Código da observação a ser excluída</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool excluirContaCartaoCliente(int iCodigoContaCartao)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM ContaCartao WHERE CodContaCartao = @codigo";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigoContaCartao));
                cmComando.ExecuteNonQuery();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    mensagemChaveEstrangeira("ContaCartao");
                else
                    System.Windows.Forms.MessageBox.Show("Erro ao excluir conta/cartão! " + ex.Message, "EstacionamentoFacil (82b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }
        /*
        /// <summary>
        /// Buscar dados de usuário
        /// </summary>
        /// <param name="iCodigoUsuario">Código de usuário para a pesquisa</param>
        /// <returns>Retorna objeto Usuario contendo os campos preenchidos</returns>
        public Usuario buscaDadosUsuario(int iCodigoUsuario)
        {
            Usuario cUsuario = null;
            string sSQL = "SELECT * FROM Usuarios WHERE cod_usuario  = @cod_usuario";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_usuario", iCodigoUsuario));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    cUsuario = new Usuario();
                    if (drLer.Read())
                    {
                        cUsuario.cod_usuario = int.Parse(drLer["cod_usuario"].ToString());
                        cUsuario.dica_senha = drLer["dica_senha"].ToString();
                        cUsuario.nomeusuario = drLer["nomeusuario"].ToString();
                        cUsuario.senha = drLer["senha"].ToString();
                        cUsuario.tipo = int.Parse(drLer["tipo"].ToString());
                        cUsuario.usuario = drLer["usuario"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de usuário! " + ex.Message, "EstacionamentoFacil (83)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return cUsuario;
        }
         * */

        /// <summary>
        /// Função para buscar todas as vendas em uma determinada situação
        /// </summary>
        /// <param name="iSituacao">0 em aberto 1 concluída 2 cancelada 3 aguardando financiamento 4 suspensa 5 Todos</param>
        /// <returns>Retorna uma lista do objeto Vendas</returns>
        public List<vendas> buscaTodasVendas(int iSituacao)
        {
            List<vendas> lstVendas = null;
            string sQuery = "";
            if (iSituacao != 5)
                sQuery = "WHERE situacao = " + iSituacao.ToString();

            string sSQL = "SELECT * FROM Vendas " + sQuery;
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstVendas = new List<vendas>();
                    while (drLer.Read())
                    {
                        lstVendas.Add(new vendas()
                        {
                            cod_carro = int.Parse(drLer["cod_carro"].ToString()),
                            cod_cliente_comprador = int.Parse(drLer["cod_cliente_comprador"].ToString()),
                            cod_cliente_vendedor = int.Parse(drLer["cod_cliente_vendedor"].ToString()),
                            cod_venda = int.Parse(drLer["cod_venda"].ToString()),
                            data_venda = DateTime.Parse(drLer["data_venda"].ToString()),
                            observacao = drLer["observacao"].ToString().Trim(),
                            situacao = int.Parse(drLer["situacao"].ToString()),
                            tipo_comissao = drLer["tipo_comissao"].ToString(),
                            tipo_venda = int.Parse(drLer["tipo_venda"].ToString()),
                            valor = double.Parse(drLer["valor"].ToString()),
                            valor_comissao = double.Parse(drLer["valor_comissao"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de vendas! " + ex.Message, "EstacionamentoFacil (84)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstVendas;
        }

        /// <summary>
        /// Função para buscar dados de uma venda
        /// </summary>
        /// <param name="iCodigoVenda">Código da venda</param>
        /// <returns>Retorna objeto venda</returns>
        public vendas buscarVenda(int iCodigoVenda)
        {
            vendas cVendas = null;
            string sSQL = "SELECT * FROM Vendas WHERE cod_venda = @cod_venda";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_venda", iCodigoVenda));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {       
                    cVendas = new vendas();
                    if (drLer.Read())
                    {
                        cVendas.cod_carro = int.Parse(drLer["cod_carro"].ToString());
                        cVendas.cod_cliente_comprador = int.Parse(drLer["cod_cliente_comprador"].ToString());
                        cVendas.cod_cliente_vendedor = int.Parse(drLer["cod_cliente_vendedor"].ToString());
                        cVendas.cod_venda = int.Parse(drLer["cod_venda"].ToString());
                        cVendas.data_venda = DateTime.Parse(drLer["data_venda"].ToString());
                        cVendas.observacao = drLer["observacao"].ToString().Trim();
                        cVendas.situacao = int.Parse(drLer["situacao"].ToString());
                        cVendas.tipo_comissao = drLer["tipo_comissao"].ToString();
                        cVendas.tipo_venda = int.Parse(drLer["tipo_venda"].ToString());
                        cVendas.valor = double.Parse(drLer["valor"].ToString());
                        cVendas.valor_comissao = double.Parse(drLer["valor_comissao"].ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de vendas! " + ex.Message, "EstacionamentoFacil (85)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return cVendas;
        }

        /// <summary>
        /// Função para retornar as comissões de uma venda
        /// </summary>
        /// <param name="iCodigoVenda">Código da venda para pesquisa</param>
        /// <returns>Retorna uma lista de comissões</returns>
        public List<vendas_vendedor> buscaComissaoVendas(int iCodigoVenda)
        {
            List<vendas_vendedor> lstVendas = null;
            string sSQL = "SELECT * FROM vendas_vendedor WHERE cod_venda = @cod_venda";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_venda", iCodigoVenda));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstVendas = new List<vendas_vendedor>();
                    while (drLer.Read())
                    {
                        lstVendas.Add(new vendas_vendedor() { 
                            cod_venda = int.Parse(drLer["cod_venda"].ToString()),
                            cod_vendedor = int.Parse(drLer["cod_vendedor"].ToString()),
                            situacao = int.Parse(drLer["situacao"].ToString()),
                            valor_comissao = double.Parse(drLer["valor_comissao"].ToString())
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de comissão de vendas! " + ex.Message, "EstacionamentoFacil (86)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return lstVendas;
        }

        /// <summary>
        /// Função para gravar dados de vendas
        /// </summary>
        /// <param name="cVenda">Objeto vendas</param>
        /// <param name="bTipo">Tipo 0 Inserir, 1 atualizar</param>
        /// <returns>Retorna T- Atualizado E-Erro ou o código da nova venda</returns>
        public string inserirAtualizarVendas(vendas cVenda, byte bTipo)
        {
            string sResposta = "E";
            string sSQL = "";
            SqlCommand cmComando;
            SqlDataReader drLer;
            double dTemp = 0;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO Vendas(cod_carro, cod_cliente_comprador, tipo_venda, valor, tipo_comissao, data_venda, cod_cliente_vendedor, situacao, observacao, valor_comissao) VALUES(@cod_carro, @cod_cliente_comprador, @tipo_venda, @valor, @tipo_comissao, @data_venda, @cod_cliente_vendedor, @situacao, @observacao, @valor_comissao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);                        
                        cmComando.Parameters.Add(new SqlParameter("@cod_carro", cVenda.cod_carro));
                        cmComando.Parameters.Add(new SqlParameter("@cod_cliente_comprador", cVenda.cod_cliente_comprador));
                        cmComando.Parameters.Add(new SqlParameter("@tipo_venda", cVenda.tipo_venda));
                        cmComando.Parameters.Add(new SqlParameter("@valor", cVenda.valor));
                        cmComando.Parameters.Add(new SqlParameter("@tipo_comissao", cVenda.tipo_comissao));
                        cmComando.Parameters.Add(new SqlParameter("@data_venda", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        cmComando.Parameters.Add(new SqlParameter("@cod_cliente_vendedor", cVenda.cod_cliente_vendedor));
                        cmComando.Parameters.Add(new SqlParameter("@situacao", cVenda.situacao));
                        cmComando.Parameters.Add(new SqlParameter("@observacao", cVenda.observacao));
                        cmComando.Parameters.Add(new SqlParameter("@valor_comissao", dTemp));

                        cmComando.ExecuteNonQuery();
                        cmComando.Dispose();

                        sSQL = "SELECT MAX(cod_venda) vUltCodigo FROM Vendas";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        drLer = cmComando.ExecuteReader();
                        if (drLer.HasRows)
                        {
                            if (drLer.Read())
                                sResposta = drLer["vUltCodigo"].ToString();
                        }
                        drLer.Dispose();
                        drLer.Close();
                        cmComando.Dispose();

                        break;
                    case 1:
                        sSQL = "UPDATE Vendas SET " +
                                 "cod_carro             = @cod_carro, " +
                                 "cod_cliente_comprador = @cod_cliente_comprador, " +
                                 "tipo_venda            = @tipo_venda, " +
                                 "valor                 = @valor, " +
                                 "tipo_comissao         = @tipo_comissao, " +
                                 "data_venda            = @data_venda, " + 
                                 "cod_cliente_vendedor  = @cod_cliente_vendedor, " +
                                 "situacao              = @situacao, " +
                                 "observacao            = @observacao, " +
                                 "valor_comissao        = @valor_comissao " +
                               "WHERE cod_venda = @cod_venda";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@cod_carro", cVenda.cod_carro));
                        cmComando.Parameters.Add(new SqlParameter("@cod_cliente_comprador", cVenda.cod_cliente_comprador));
                        cmComando.Parameters.Add(new SqlParameter("@tipo_venda", cVenda.tipo_venda));
                        cmComando.Parameters.Add(new SqlParameter("@valor", cVenda.valor));
                        cmComando.Parameters.Add(new SqlParameter("@tipo_comissao", cVenda.tipo_comissao));
                        cmComando.Parameters.Add(new SqlParameter("@data_venda", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        cmComando.Parameters.Add(new SqlParameter("@cod_cliente_vendedor", cVenda.cod_cliente_vendedor));
                        cmComando.Parameters.Add(new SqlParameter("@situacao", cVenda.situacao));
                        cmComando.Parameters.Add(new SqlParameter("@observacao", cVenda.observacao));
                        cmComando.Parameters.Add(new SqlParameter("@valor_comissao", dTemp));
                        cmComando.Parameters.Add(new SqlParameter("@cod_venda", cVenda.cod_venda));
                        cmComando.ExecuteNonQuery();
                        cmComando.Dispose();
                        sResposta = "T";

                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao atualizar/inserir vendas! " + ex.Message, "EstacionamentoFacil (87)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                sResposta = "E";
            }
            return sResposta;
        }

        /// <summary>
        /// Função para inserir/atualizar comissões
        /// </summary>
        /// <param name="cVendasVendedor">Objeto vendas_vendedor</param>
        /// <param name="bTipo">Tipo 0 - inserir, 1 - atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarComissao(vendas_vendedor cVendasVendedor, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando;
            
            try
            {
                switch (bTipo)
                {
                    case 0:
                        //inserir
                        sSQL = "INSERT INTO vendas_vendedor(cod_venda, cod_vendedor, valor_comissao, situacao) VALUES(@cod_venda, @cod_vendedor, @valor_comissao, @situacao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@cod_venda", cVendasVendedor.cod_venda));
                        cmComando.Parameters.Add(new SqlParameter("@cod_vendedor", cVendasVendedor.cod_vendedor));
                        cmComando.Parameters.Add(new SqlParameter("@valor_comissao", cVendasVendedor.valor_comissao));
                        cmComando.Parameters.Add(new SqlParameter("@situacao", cVendasVendedor.situacao));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                    case 1:
                        //atualizar
                        sSQL = "UPDATE vendas_vendedor SET " + 
                                 "valor_comissao = @valor_comissao, " + 
                                 "situacao = @situacao " +
                               "WHERE cod_venda = @cod_venda AND cod_vendedor = @cod_vendedor";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);                        
                        cmComando.Parameters.Add(new SqlParameter("@valor_comissao", cVendasVendedor.valor_comissao));
                        cmComando.Parameters.Add(new SqlParameter("@situacao", cVendasVendedor.situacao));
                        cmComando.Parameters.Add(new SqlParameter("@cod_venda", cVendasVendedor.cod_venda));
                        cmComando.Parameters.Add(new SqlParameter("@cod_vendedor", cVendasVendedor.cod_vendedor));
                        cmComando.ExecuteNonQuery();
                        bResposta = true;
                        break;
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao atualizar/inserir comissão! " + ex.Message, "EstacionamentoFacil (88)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return bResposta;
        }

        /// <summary>
        /// Buscar dados de Comissão
        /// </summary>
        /// <param name="iCodVenda">Cod de venda</param>
        /// <param name="iCodVendedor">Cod de vendedor</param>
        /// <returns>Retorna o objeto vendas_vendedor</returns>
        public vendas_vendedor buscaVendasVendedor(int iCodVenda, int iCodVendedor)
        {
            vendas_vendedor cVendasVendedor = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM vendas_vendedor WHERE cod_venda = @cod_venda AND cod_vendedor = @cod_vendedor";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_venda", iCodVenda));
                cmComando.Parameters.Add(new SqlParameter("@cod_vendedor", iCodVendedor));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    cVendasVendedor = new vendas_vendedor();
                    if (drLer.Read())
                    {
                        cVendasVendedor.cod_venda = int.Parse(drLer["cod_venda"].ToString());
                        cVendasVendedor.cod_vendedor = int .Parse(drLer["cod_vendedor"].ToString());
                        cVendasVendedor.valor_comissao = double.Parse(drLer["valor_comissao"].ToString());
                        cVendasVendedor.situacao = int.Parse(drLer["situacao"].ToString());
                    }
                }                
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de comissão! " + ex.Message, "EstacionamentoFacil (89)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return cVendasVendedor;
        }

        /// <summary>
        /// Função para excluir uma comissão
        /// </summary>
        /// <param name="iCodVenda">Cod venda</param>
        /// <param name="iCodVendedor">Cod vendedor</param>
        /// <returns>Retorna verdaeiro ou falso mediante a execuçaõ da função</returns>
        public bool excluirVendasVendedor(int iCodVenda, int iCodVendedor)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM vendas_vendedor WHERE cod_venda = @cod_venda AND cod_vendedor = @cod_vendedor";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_venda", iCodVenda));
                cmComando.Parameters.Add(new SqlParameter("@cod_vendedor", iCodVendedor));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao excluir dados de comissão!\n" + ex.Message, "EstacionamentoFacil (90)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para excluir vículo de carro com cliente
        /// </summary>
        /// <param name="iCodCarro">Código do carro para exclusão</param>
        /// <returns>Retorna verdadei ou falso mediante a execução da função.</returns>
        public bool excluirClienteCarro(int iCodCarro)
        {
            bool bResposta = false;
            string sSQL = "DELETE FROM ClienteCarro WHERE codigocarro = @codigocarro";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigocarro", iCodCarro));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao excluir dados de vículo do veículo com cliente!\n" + ex.Message, "EstacionamentoFacil (91)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para pesquisar o cliente que pertence este veículo
        /// </summary>
        /// <param name="iCodCarro">Código do veículo</param>
        /// <returns>Retorna o código do cliente</returns>
        public int buscaClienteCarro(int iCodCarro)
        {
            int iResposta = 0;
            string sSQL = "SELECT * FROM ClienteCarro WHERE codigocarro = @codigocarro";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigocarro",iCodCarro));
                drLer = cmComando.ExecuteReader();
                if(drLer.HasRows){
                    if(drLer.Read())
                        iResposta = int.Parse(drLer["codigocliente"].ToString());
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();

            }catch(SqlException ex){
                System.Windows.Forms.MessageBox.Show("Erro ao pesquisar dados de vículo do veículo com cliente!\n" + ex.Message, "EstacionamentoFacil (92)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            return iResposta;
        }

        /// <summary>
        /// Função para inserir/atualizar dados de usuário
        /// </summary>
        /// <param name="obUsuario">Objeto Usuário</param>
        /// <param name="bTipo">Tipo 0 - inserir 1 - atualizar</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool inserirAtualizarUsuario(usuario obUsuario, byte bTipo)
        {
            bool bResposta = false;
            string sSQL = "";
            SqlCommand cmComando = null;
            try
            {
                switch (bTipo)
                {
                    case 0:
                        sSQL = "INSERT INTO Usuarios (senha, tipo, dica_senha, usuario, nomeusuario, situacao, observacao) VALUES(@senha, @tipo, @dica_Senha,@usuario,@nomeusuario, @situacao, @observacao)";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@senha",obUsuario.senha));
                        cmComando.Parameters.Add(new SqlParameter("@tipo", obUsuario.tipo));
                        cmComando.Parameters.Add(new SqlParameter("@dica_senha", obUsuario.dica_senha));
                        cmComando.Parameters.Add(new SqlParameter("@usuario", obUsuario.sUsuario));
                        cmComando.Parameters.Add(new SqlParameter("@nomeusuario", obUsuario.nomeusuario));
                        cmComando.Parameters.Add(new SqlParameter("@situacao", obUsuario.situacao));
                        cmComando.Parameters.Add(new SqlParameter("@observacao", obUsuario.observacao));
                        cmComando.ExecuteNonQuery();
                        break;
                    case 1:
                        sSQL = "UPDATE Usuarios SET " + 
                                 "senha       = @senha, " +
                                 "tipo        = @tipo, " +
                                 "dica_senha  = @dica_senha, " + 
                                 "usuario     = @usuario, " + 
                                 "nomeusuario = @nomeusuario, " +
                                 "situacao    = @situacao, " +
                                 "observacao  = @observacao " +
                               "WHERE cod_usuario = @cod_usuario";
                        cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                        cmComando.Parameters.Add(new SqlParameter("@senha",obUsuario.senha));
                        cmComando.Parameters.Add(new SqlParameter("@tipo", obUsuario.tipo));
                        cmComando.Parameters.Add(new SqlParameter("@dica_senha", obUsuario.dica_senha));
                        cmComando.Parameters.Add(new SqlParameter("@usuario", obUsuario.sUsuario));
                        cmComando.Parameters.Add(new SqlParameter("@nomeusuario", obUsuario.nomeusuario));
                        cmComando.Parameters.Add(new SqlParameter("@situacao", obUsuario.situacao));
                        cmComando.Parameters.Add(new SqlParameter("@observacao", obUsuario.observacao));
                        cmComando.Parameters.Add(new SqlParameter("@cod_usuario", obUsuario.cod_usuario));
                        cmComando.ExecuteNonQuery();
                        break;
                }                
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao gravar dados de usuário!\n" + ex.Message, "EstacionamentoFacil (93)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para alterar a senha do usuário
        /// </summary>
        /// <param name="obUsuario">Objeto usuário</param>
        /// <param name="novaSenha">Nova senha</param>
        /// <param name="novaDica">Dica da nova senha</param>
        /// <returns></returns>
        public bool alterarSenhaUsuario(usuario obUsuario, string novaSenha, string novaDica)
        {
            bool bResposta = false;
            string sSQL = "UPDATE Usuarios SET senha = @senha, dica_senha = @dica_senha WHERE cod_usuario = @cod_usuario";
            SqlCommand cmComando;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@senha", novaSenha));
                cmComando.Parameters.Add(new SqlParameter("@dica_senha", novaDica));
                cmComando.Parameters.Add(new SqlParameter("@cod_usuario", obUsuario.cod_usuario));
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao atualizar a senha do usuário!\n" + ex.Message, "EstacionamentoFacil (94)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para buscar os dados de Usuario
        /// </summary>
        /// <param name="iCodigoUsuario">Código do usuário</param>
        /// <returns>Retorna objeto Usuario</returns>
        public usuario buscaDadosUsuario(int iCodigoUsuario)
        {
            usuario obUsuario = null;
            string sSQL = "SELECT * FROM Usuarios WHERE cod_usuario = @cod_usuario";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@cod_usuario",iCodigoUsuario));
                drLer = cmComando.ExecuteReader();
                if(drLer.HasRows){
                    obUsuario = new usuario();
                    if (drLer.Read())
                    {
                        obUsuario.cod_usuario = int.Parse(drLer["cod_usuario"].ToString());
                        obUsuario.dica_senha = drLer["dica_senha"].ToString();
                        obUsuario.nomeusuario = drLer["nomeusuario"].ToString();
                        obUsuario.observacao = drLer["observacao"].ToString();
                        obUsuario.senha = drLer["senha"].ToString();
                        obUsuario.situacao = int.Parse(drLer["situacao"].ToString());
                        obUsuario.sUsuario = drLer["usuario"].ToString();
                        obUsuario.tipo = int.Parse(drLer["tipo"].ToString());
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao atualizar a senha do usuário!\n" + ex.Message, "EstacionamentoFacil (94)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return obUsuario;
        }
        
        /// <summary>
        /// Função para retornar uma lista contendo todos os usuários, mediante a sua situação
        /// </summary>
        /// <param name="iSituacao">Situacao 0 - Ativos 1 - Inativos 2 - Cancelados 5 - TODOS</param>
        /// <returns>Retorna uma lista do objeto usuário</returns>
        public List<usuario> buscaTodosUsuario(int iSituacao)
        {
            List<usuario> lstUsuario = null;
            string sSituacao="";
            if (iSituacao != 5)
                sSituacao = " WHERE situacao = " + iSituacao.ToString();
            string sSQL = "SELECT * FROM Usuarios " + sSituacao + " ORDER BY usuario";
            SqlCommand cmComando;
            SqlDataReader drLer;

            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstUsuario = new List<usuario>();
                    while (drLer.Read())
                    {
                        lstUsuario.Add(new usuario { 
                            cod_usuario = int.Parse(drLer["cod_usuario"].ToString()),
                            dica_senha = drLer["dica_senha"].ToString(),
                            nomeusuario = drLer["nomeusuario"].ToString(),
                            observacao = drLer["observacao"].ToString(),
                            senha = drLer["senha"].ToString(),
                            situacao = int.Parse(drLer["situacao"].ToString()),
                            sUsuario = drLer["usuario"].ToString(),
                            tipo = int.Parse(drLer["tipo"].ToString())
                        });
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de usuários!\n" + ex.Message, "EstacionamentoFacil (95)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstUsuario;
        }

        /// <summary>
        /// Função para retornar uma lista de níveis de acesso
        /// </summary>
        /// <returns>Retorna uma lista com o objeto nivelacesso</returns>
        public List<nivelAcesso> buscaNivelAcesso()
        {
            List<nivelAcesso> lstNivelAcesso = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM Usuarios_NivelAcesso";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstNivelAcesso = new List<nivelAcesso>();
                    while (drLer.Read())
                    {
                        lstNivelAcesso.Add(new nivelAcesso { 
                            codigo = int.Parse(drLer["codigo"].ToString()),
                            nivelacesso = drLer["nivelacesso"].ToString()
                        });
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de nível de acesso!\n" + ex.Message, "EstacionamentoFacil (96)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstNivelAcesso;
        }

        public nivelAcesso buscaNivelAcessoS(int iCodigo)
        {
            nivelAcesso obNivelAcesso= null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM Usuarios_NivelAcesso WHERE codigo = @codigo";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@codigo", iCodigo));
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    obNivelAcesso = new nivelAcesso();
                    if (drLer.Read())
                    {
                        obNivelAcesso.nivelacesso = drLer["nivelacesso"].ToString();
                        obNivelAcesso.codigo = int.Parse(drLer["codigo"].ToString());
                    }
                }
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de nível de acesso!\n" + ex.Message, "EstacionamentoFacil (97)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return obNivelAcesso;
        }

        /// <summary>
        /// Função para buscar histórico do cliente
        /// </summary>
        /// <param name="iCodigoCliente">Código do cliente</param>
        /// <returns>Retorna uma lista do objeto histcliente</returns>
        public List<histCliente> buscarHistoricoCliente(int iCodigoCliente)
        {
            List<histCliente> lstHistorico = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT v.cod_venda, v.cod_carro, v.data_venda,  (CASE WHEN v.cod_cliente_comprador = " + iCodigoCliente.ToString() + " THEN 'COMPRA' WHEN v.cod_cliente_vendedor = " + iCodigoCliente.ToString() + " THEN 'VENDA' END) vOperacao FROM vendas v INNER JOIN Carro c ON v.cod_carro = c.Codigo WHERE (v.cod_cliente_comprador = " + iCodigoCliente.ToString() + " OR v.cod_cliente_vendedor = " + iCodigoCliente.ToString() + " ) ORDER BY v.data_venda DESC";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstHistorico = new List<histCliente>();
                    while (drLer.Read())
                    {
                        lstHistorico.Add(new histCliente()
                        {
                            CodCarro = int.Parse(drLer["cod_carro"].ToString()),
                            CodVenda = int.Parse(drLer["cod_venda"].ToString()),
                            dataHist = DateTime.Parse(drLer["data_venda"].ToString()),
                            operacao = drLer["vOperacao"].ToString().Trim()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de histórico de cliente!\n" + ex.Message, "EstacionamentoFacil (98)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstHistorico;
        }

        public List<ContaCartaoCliente> buscarContaCartaoCliente(int iCodigoCliente)
        {
            List<ContaCartaoCliente> lstContaCartao = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM ContaCartao WHERE CodCliente = " + iCodigoCliente.ToString();
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstContaCartao = new List<ContaCartaoCliente>();
                    while (drLer.Read())
                    {
                        lstContaCartao.Add(new ContaCartaoCliente()
                        {
                            CodContaCartao = int.Parse(drLer["CodContaCartao"].ToString()),
                            CodCliente = int.Parse(drLer["CodCliente"].ToString()),
                            Tipo = int.Parse(drLer["Tipo"].ToString()),
                            Numero = drLer["Numero"].ToString(),
                            Bandeira = drLer["Bandeira"].ToString(),
                            NomeBanco = drLer["NomeBanco"].ToString(),
                            Agencia = drLer["Agencia"].ToString(),
                            NumConta = drLer["NumConta"].ToString(),
                            CPF = drLer["CPF"].ToString(),
                            CNPJ = drLer["CNPJ"].ToString(),
                            Obs = drLer["Obs"].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de conta/cartão de cliente!\n" + ex.Message, "EstacionamentoFacil (98b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstContaCartao;
        }

        /// <summary>
        /// Função para pesquisar auditorias
        /// </summary>
        /// <param name="sQuery">Cláusula de pesquisa</param>
        /// <returns>Retorna uma lista de auditorias</returns>
        public List<auditoria> buscaAuditorias(string sQuery)
        {
            List<auditoria> lstAuditoria = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT a.* FROM Auditoria a " + sQuery + " ORDER BY a.data_operacao DESC";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstAuditoria = new List<auditoria>();
                    while (drLer.Read())
                    {
                        lstAuditoria.Add(new auditoria()
                        {
                            codigo = int.Parse(drLer["codigo"].ToString()),
                            cod_usuario = int.Parse(drLer["cod_usuario"].ToString()),
                            data_operacao = DateTime.Parse(drLer["data_operacao"].ToString()),
                            descritivo = drLer["descritivo"].ToString(),
                            operacao = int.Parse(drLer["operacao"].ToString()),
                            tela = drLer["tela"].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de auditoria!\n" + ex.Message, "EstacionamentoFacil (99)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstAuditoria;
        }

        /// <summary>
        /// Função para preencher a tabela temporaria para impressão de auditorias
        /// </summary>
        /// <param name="sQuery">Cláusula de pesquisa</param>
        /// <param name="sFiltro">Filtros selecionados</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool buscaAuditorias(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "DELETE FROM temporarioimpressao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                sSQL = "INSERT INTO temporarioimpressao(indice, texto01, texto02, texto03, texto04, texto05, texto15, data01) " +
                       "SELECT a.codigo, ao.descricao vDescricaoOperacao, a.descritivo, u.nomeusuario, CONVERT(nvarchar(20),a.data_operacao,103) + ' ' + CONVERT(nvarchar(20),a.data_operacao,108) vHoraOperacao, '" + sFiltro + "' vFiltro, (SELECT nome_fantasia FROM empresa) vEmpresa, a.data_operacao FROM auditoria a INNER JOIN auditoria_operacao ao ON a.operacao = ao.operacao INNER JOIN Usuarios u ON a.cod_usuario = u.cod_usuario" +
                       " " + sQuery + " ORDER BY a.data_operacao DESC";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de auditoria!\n" + ex.Message, "EstacionamentoFacil (99)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar uma lista de operações de auditoria
        /// </summary>
        /// <returns>Retorna uma lista auditoria_operacao</returns>
        public List<auditoria_operacao> buscaOperacaoAuditoria()
        {
            List<auditoria_operacao> lstAuditoria = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM auditoria_operacao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstAuditoria = new List<auditoria_operacao>();
                    while (drLer.Read())
                    {
                        lstAuditoria.Add(new auditoria_operacao()
                        {
                            operacao = int.Parse(drLer["operacao"].ToString()),
                            descricao = drLer["descricao"].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de auditoria!\n" + ex.Message, "EstacionamentoFacil (100)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstAuditoria;
        }

        /// <summary>
        /// Função para buscar uma determinada operação
        /// </summary>
        /// <param name="iCodigo">Código da operação</param>
        /// <returns>Retorna o objeto auditoria_operacao</returns>
        public auditoria_operacao buscaOperacaoAuditoria(int iCodigo)
        {
            auditoria_operacao obAuditoria = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM auditoria_operacao WHERE operacao = " + iCodigo.ToString();
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    obAuditoria = new auditoria_operacao();
                    if (drLer.Read())
                    {
                        obAuditoria.descricao = drLer["descricao"].ToString().Trim();
                        obAuditoria.operacao = int.Parse(drLer["operacao"].ToString());
                    }                        
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de auditoria!\n" + ex.Message, "EstacionamentoFacil (101)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return obAuditoria;
        }

        /// <summary>
        /// Função para localizar dados de um cliente na tela de Localização.
        /// </summary>
        /// <param name="sFiltro">Filtro para pesquisa</param>
        /// <returns>Retorna lista de objeto Cliente</returns>
        public List<cliente> localizarDadosCliente(string sFiltro)
        {
            List<cliente> lstCliente = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM Cliente ";
            if (sFiltro.Trim().Length > 0)
                sSQL = sSQL + " WHERE " + sFiltro + " AND TipoCliente = 0";
            else
                sSQL = sSQL + "WHERE TipoCliente = 0";
            //determinar ordenação
            sSQL = sSQL + " ORDER BY Nome";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstCliente = new List<cliente>();
                    while (drLer.Read())
                    {
                        lstCliente.Add(new cliente()
                        {
                            Codigo = int.Parse(drLer["Codigo"].ToString()),
                            Nome = drLer["Nome"].ToString().Trim(),
                            CPF = drLer["CPF"].ToString().Trim(),
                            Email = drLer["Email"].ToString().Trim(),
                            Cod_logradouro = int.Parse(drLer["Cod_logradouro"].ToString()),
                            Numero = int.Parse(drLer["Numero"].ToString()),
                            Observacao = drLer["Observacao"].ToString(),
                            TipoCliente = int.Parse(drLer["TipoCliente"].ToString()),
                            TipoPessoa = int.Parse(drLer["TipoPessoa"].ToString()),
                            DtNascimento = DateTime.Parse(drLer["DtNascimento"].ToString()),
                            DtCadastro = DateTime.Parse(drLer["DtCadastro"].ToString()),
                            DtRenovacaoSeguro = DateTime.Parse(drLer["DtRenovacaoSeguro"].ToString()),
                            Profissao = drLer["Profissao"].ToString(),
                            Status = int.Parse(drLer["Status"].ToString()),
                            Sexo = int.Parse(drLer["Sexo"].ToString()),
                            EstadoCivil = drLer["EstadoCivil"].ToString(),
                            FaixaSalarial = int.Parse(drLer["FaixaSalarial"].ToString()),
                            CNH = drLer["CNH"].ToString(),
                            ValidadeCNH = DateTime.Parse(drLer["ValidadeCNH"].ToString()),
                            CategoriaCNH = drLer["CategoriaCNH"].ToString(),
                            DtPrimeiraCNH = DateTime.Parse(drLer["DtPrimeiraCNH"].ToString())
                        });
                    }
                    drLer.Dispose();
                    drLer.Close();
                    cmComando.Dispose();
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de clientes!\n" + ex.Message, "EstacionamentoFacil (301)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstCliente;
        }

        /// <summary>
        /// Função para localizar dados de um veículo na tela de Localização.
        /// </summary>
        /// <param name="sFiltro">Filtro para pesquisa</param>
        /// <returns>Retorna objeto Carro</returns>
        public List<carro> localizaDadosCarro(string sFiltro)
        {
            List<carro> lstCarro = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM Carro ";
            if(sFiltro.Trim().Length > 0) sSQL = sSQL + " WHERE " + sFiltro;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstCarro = new List<carro>();
                    while (drLer.Read())
                    {
                        lstCarro.Add(new carro()
                        {
                            AnoFab = int.Parse(drLer["AnoFab"].ToString().Trim()),
                            AnoMod = int.Parse(drLer["AnoMod"].ToString().Trim()),
                            Chassi = int.Parse(drLer["Chassi"].ToString().Trim()),
                            Chassi2 = drLer["Chassi2"].ToString().Trim(),
                            Codigo = int.Parse(drLer["Codigo"].ToString().Trim()),
                            CodMarca = int.Parse(drLer["CodMarca"].ToString().Trim()),
                            Configuracao = int.Parse(drLer["Configuracao"].ToString().Trim()),
                            cor = drLer["Cor"].ToString().Trim(),
                            Lugares = int.Parse(drLer["Lugares"].ToString().Trim()),
                            Modelo = drLer["Modelo"].ToString().Trim(),
                            Num_motor = drLer["Num_motor"].ToString().Trim(),
                            Placa = int.Parse(drLer["Placa"].ToString().Trim()),
                            Placa2 = drLer["Placa2"].ToString().Trim(),
                            Potencia = int.Parse(drLer["Potencia"].ToString().Trim()),
                            Procedencia = int.Parse(drLer["Procedencia"].ToString().Trim()),
                            QtdePortas = int.Parse(drLer["QtdePortas"].ToString().Trim()),
                            Renavan = int.Parse(drLer["Renavan"].ToString().Trim()),
                            Renavan2 = drLer["Renavan2"].ToString().Trim(),
                            Rpm = int.Parse(drLer["Rpm"].ToString().Trim()),
                            Serie = drLer["Serie"].ToString().Trim(),
                            Situacao = drLer["Situacao"].ToString().Trim(),
                            Torque = float.Parse(drLer["Torque"].ToString().Trim()),
                            Tracao = int.Parse(drLer["Tracao"].ToString().Trim()),
                            Transmissao = int.Parse(drLer["Transmissao"].ToString().Trim())
                        });
                    }
                    drLer.Dispose();
                    drLer.Close();
                    cmComando.Dispose();
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados do veículo!\n" + ex.Message, "EstacionamentoFacil (300)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstCarro;

        }

        /// <summary>
        /// Função para retornar os dados da empresa
        /// </summary>
        /// <returns>Retorna objeto Empresa</returns>
        public empresa buscaDadosEmpresa()
        {
            empresa cEmpresa = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM empresa";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    cEmpresa = new empresa();
                    if (drLer.Read())
                    {
                        cEmpresa.cnpj = drLer["cnpj"].ToString().Trim();
                        cEmpresa.cod_empresa = int.Parse(drLer["cod_empresa"].ToString());
                        cEmpresa.cod_logradouro = int.Parse(drLer["cod_logradouro"].ToString());
                        cEmpresa.email = drLer["email"].ToString().Trim();
                        cEmpresa.licenca = drLer["licenca"].ToString().Trim();
                        cEmpresa.nome_empresa = drLer["nome_empresa"].ToString().Trim();
                        cEmpresa.nome_fantasia = drLer["nome_fantasia"].ToString().Trim();
                        cEmpresa.numero = int.Parse(drLer["numero"].ToString());
                        cEmpresa.proprietario = drLer["proprietario"].ToString().Trim();
                        cEmpresa.telefone01 = drLer["telefone01"].ToString().Trim();
                        cEmpresa.telefone02 = drLer["telefone02"].ToString().Trim();
                        cEmpresa.tipo_relatorio = int.Parse(drLer["TipoRelatorio"].ToString());
                    }
                    drLer.Dispose();
                    drLer.Close();
                    cmComando.Dispose();
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados da empresa!\n" + ex.Message, "EstacionamentoFacil (102)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return cEmpresa;
        }

        /// <summary>
        /// Função para gravar os dados da empresa
        /// </summary>
        /// <param name="cEmpresa">Objeto empresa</param>
        /// <returns>REtorna verdadeiro ou falso mediante a execução da função</returns>
        public bool gravarDadosEmpresa(empresa cEmpresa)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "";
            try
            {
                sSQL = "UPDATE empresa SET " +
                          "nome_empresa   = @nome_empresa, " +
                          "nome_fantasia  = @nome_fantasia, " +
                          "telefone01     = @telefone01, " +
                          "telefone02     = @telefone02, " +
                          "cnpj           = @cnpj, " +
                          "email          = @email, " +
                          "proprietario   = @proprietario, " +
                          "cod_logradouro = @cod_logradouro, " +
                          "numero         = @numero, " +
                          "licenca        = @licenca, " +
                          "TipoRelatorio  = @TipoRelatorio ";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.Parameters.Add(new SqlParameter("@nome_empresa", cEmpresa.nome_empresa));
                cmComando.Parameters.Add(new SqlParameter("@nome_fantasia", cEmpresa.nome_fantasia));
                cmComando.Parameters.Add(new SqlParameter("@telefone01", cEmpresa.telefone01));
                cmComando.Parameters.Add(new SqlParameter("@telefone02", cEmpresa.telefone02));
                cmComando.Parameters.Add(new SqlParameter("@cnpj", cEmpresa.cnpj));
                cmComando.Parameters.Add(new SqlParameter("@email", cEmpresa.email));
                cmComando.Parameters.Add(new SqlParameter("@proprietario", cEmpresa.proprietario));
                cmComando.Parameters.Add(new SqlParameter("@cod_logradouro", cEmpresa.cod_logradouro));
                cmComando.Parameters.Add(new SqlParameter("@numero", cEmpresa.numero));
                cmComando.Parameters.Add(new SqlParameter("@licenca", cEmpresa.licenca));
                cmComando.Parameters.Add(new SqlParameter("@TipoRelatorio", cEmpresa.tipo_relatorio));

                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados da empresa!\n" + ex.Message, "EstacionamentoFacil (103)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para gerar o relatório de impressão
        /// </summary>
        /// <returns>Retorna CrystalReportViewer</returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer imprimirAuditoria()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet1 vCust;
            Relatórios.Auditoria vCrystal;

            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;                
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                vCrystal = new Relatórios.Auditoria();
                vCrystal.SetDataSource(vCust);
                relatorio.ReportSource = vCrystal;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar abrir tela de impressão!\n" + ex.Message, "EstacionamentoFacil (104)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return relatorio;
        }

        
        public DataSet imprimirAuditoriaW()
        {
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet vCust;            
            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet();                
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                return vCust;
                daLer.Dispose();
                cmComando.Dispose();                
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar abrir tela de impressão(b)!\n" + ex.Message, "EstacionamentoFacil (104)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            
        }
        
        /// <summary>
        /// Função para gerar dados para a impressão de relatório de clientes cadastrados
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <param name="sFiltro">Filtro para pesquisa</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_ClientesCadastrados(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "DELETE FROM temporarioimpressao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                sSQL = "INSERT INTO temporarioimpressao(indice, texto01, texto02, texto03, texto04, memo01, memo02, texto05, texto06, texto15, texto07, texto08)  " +
                       "SELECT " +
                        "c.Codigo, " +
                        "c.Nome, " +
                        "c.CPF, " +
                        "c.RG, " + 
                        "c.Email, " +
                        "STUFF( " +
                            "( " +
                                "SELECT " +
                                    "', ' + '(' + t.ddd + ') ' + RTRIM(LTRIM(t.telefone)) + ' - ' + rtrim(ltrim(o.operadora)) " +
                                "FROM " +
                                    "Telefone t " +
                                        "INNER JOIN Operadora o          ON t.codoperadora = o.codigo " +
                                        "INNER JOIN TelefonesClientes tc ON t.codtelefone = tc.CodigoCliente " +
                                        "INNER JOIN Cliente cc           ON tc.CodigoCliente = cc.Codigo  " +
                                "WHERE " +
                                    "cc.Codigo = c.codigo " +
                                "FOR XML PATH('') " +
                            "),1,1,'' " + 
                        ") AS vTelefones, " + 
                        "STUFF( " +
                            "( " +
                                "SELECT " +
                                    "', ' + ltrim(rtrim(ca.Placa2)) + ' - ' + ltrim(rtrim(marca.Descricao)) + ' - ' + ltrim(rtrim(ca.Modelo)) " +
                                "FROM " +
                                    "Carro ca " +
                                        "INNER JOIN ClienteCarro clicarr ON ca.Codigo  = clicarr.codigocarro " +
                                        "INNER JOIN Marca2 marca         ON ca.CodMarca = marca.Codigo " +
                                        "INNER JOIN Cliente cli          ON clicarr.codigocliente = cli.Codigo " +
                                "WHERE " +
                                    "cli.Codigo = c.codigo " +
                                "FOR XML PATH('') " +
                            "),1,1,'' " +
                        ") AS vVeiculos, " +
                        "ltrim(rtrim(lt.abreviacao)) + ' ' + ltrim(rtrim(l.Nome_logradouro)) + ', ' + convert(varchar,c.Numero) +	' - ' + ltrim(rtrim(b.Nome_bairro)) + ' - ' + ltrim(rtrim(m.Nome_municipio)) + '/' + ltrim(rtrim(m.UF)) vEnderecoCompleto, " +
                        "'" + sFiltro + "' vFiltro, " + 
                        "(SELECT nome_fantasia FROM empresa) vEmpresa, " +
                        "ltrim(rtrim(lt.abreviacao)) + ' ' + ltrim(rtrim(l.Nome_logradouro)) + ', ' + convert(varchar,c.Numero) +	' - ' + ltrim(rtrim(b.Nome_bairro)) vvEndRua, " +
                        "ltrim(rtrim(m.Nome_municipio)) + '/' + ltrim(rtrim(m.UF)) + ' CEP:' + SUBSTRING(ltrim(rtrim(l.CEP)),1,5) + '-' + SUBSTRING(ltrim(rtrim(l.CEP)),6,3) " +
                        "FROM " +
                            "cliente c " +
                                "INNER JOIN Logradouro l       ON c.Cod_logradouro = l.Codigo " +
                                "INNER JOIN Logradouro_tipo lt ON l.Tipo = lt.codigo "+
                                "INNER JOIN Bairro b           ON l.Cod_bairro = b.Codigo " +
                                "INNER JOIN Localidade lo      ON lo.Codigo = b.Cod_localidade " +
                                "INNER JOIN Municipio m        ON lo.Cod_municipio = m.Codigo " + sQuery;
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de clientes cadastrados!\n" + ex.Message, "EstacionamentoFacil (105)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para a impressão do relatório
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_ClientesCadastrados()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet1 vCust;
            Relatórios.ClientesCadastrados vCrystal;

            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY texto01";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                vCrystal = new Relatórios.ClientesCadastrados();
                vCrystal.SetDataSource(vCust);
                relatorio.ReportSource = vCrystal;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar abrir tela de impressão!\n" + ex.Message, "EstacionamentoFacil (106)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return relatorio;
        }

        /// <summary>
        /// Função para impressão de relatório
        /// </summary>
        /// <param name="bTipo">Tipo</param>
        /// <returns>Retorna DataSet contendo o temporario impressão</returns>
        public DataSet impr_ClientesCadastrados(byte bTipo)
        {
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet vCust;
            
            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY texto01";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                return vCust;
                daLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar abrir tela de impressão!\n" + ex.Message, "EstacionamentoFacil (106)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                vCust = null;
            }
            return vCust;
        }

        /// <summary>
        /// Função para prepara a tabela temporaria para impressão
        /// </summary>
        /// <param name="sQuery">Cláusula SQL para pesquisa</param>
        /// <param name="sFiltro">Filtro que foi pesquisado para exibição em relatório</param>
        /// <returns>Retorna verdadeirou ou falso mediante a execução da função</returns>
        public bool impr_VeiculosCadastrados(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "DELETE FROM temporarioimpressao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                sSQL = "INSERT INTO temporarioimpressao(indice, texto01, texto02, texto03, numero01, numero02, numero03, texto04, numero04, texto05, numero05, numero06, numero07, numero08, numero09, double01, texto06, texto07, texto08, texto09, memo01, memo02, texto14, texto15) " +
                       "SELECT " +
                            "car.Codigo, " +
                            "car.Placa2, " +
                            "car.Modelo, " +
                            "car.Serie, " +
                            "car.Placa, " +
                            "car.AnoFab, " +
                            "car.AnoMod, " +
                            "car.Cor,  " +
                            "car.QtdePortas, " +
                            "car.Num_motor, " +
                            "car.Lugares, " +
                            "car.Transmissao, " +
                            "car.Tracao, " +
                            "car.Potencia, " +
                            "car.Rpm, " +
                            "car.Torque, " +
                            "car.chassi2, " +
                            "car.Renavan2, " +
                            "marca.Descricao vMarca, " +
                            "(CASE WHEN car.situacao = 'A' THEN 'ATIVO' WHEN car.situacao = 'E' THEN 'EXCLUÍDO' WHEN car.situacao = 'H' THEN 'HISTÓRICO' END) vSituacao, " +
                            "STUFF((SELECT ', ' + ltrim(rtrim(cl.Nome)) + ' - ' + ltrim(rtrim(cl.CPF)) FROM Cliente cl INNER JOIN ClienteCarro cc ON cl.Codigo = cc.codigocliente WHERE cc.codigocarro = car.Codigo FOR XML PATH('')),1,1,'') AS vClientes, " +
                            "STUFF((SELECT ', ' + ltrim(rtrim(op.Descricao)) FROM Opicionais op INNER JOIN Carro_Opcionais cop ON op.Codigo = cop.CodOpcionais WHERE cop.CodCarro = car.Codigo FOR XML PATH('')),1,1,'') AS vOpcionais, " +
                            "'" + sFiltro + "' vFiltro, " +
                            "(SELECT nome_fantasia FROM empresa) vNomeEmpresa " +
                       "FROM " +
                            "Carro car " +
                            "	INNER JOIN Marca2 marca ON car.CodMarca = marca.Codigo " + sQuery;
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de veículos cadastrados!\n" + ex.Message, "EstacionamentoFacil (107)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_VeiculosCadastrados()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet1 vCust;
            Relatórios.VeiculosCadastrados vCrystal;

            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY texto01";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                vCrystal = new Relatórios.VeiculosCadastrados();
                vCrystal.SetDataSource(vCust);
                relatorio.ReportSource = vCrystal;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (108)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return relatorio;
        }

        public DataSet impr_VeiculosCadastrados(byte bTipo)
        {
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet vCust;
            
            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY texto01";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                return vCust;
                daLer.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (108)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para pesquisa para preenchinto de dados de veículos
        /// </summary>
        /// <param name="iTipo">Tipo 0 qte potas, 1 Qte lugares, 2 cor</param>
        /// <returns>Retorna uma lista do objeto retornoConsultaVeiculos</returns>
        public List<retornoConsultaVeiculos> retornoConsultaVeiculo(int iTipo)
        {
            List<retornoConsultaVeiculos> lstRetorno = null;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "";
            try
            {
                switch (iTipo)
                {                    
                    case 0:
                        sSQL = "SELECT DISTINCT CONVERT(VARCHAR, QtdePortas) vTexto FROM Carro ORDER BY CONVERT(VARCHAR, QtdePortas)";
                        break;
                    case 1:
                        sSQL = "SELECT DISTINCT CONVERT(VARCHAR, Lugares) vTexto FROM Carro ORDER BY CONVERT(VARCHAR, Lugares)";
                        break;
                    case 2:
                        sSQL = "SELECT DISTINCT Cor vTexto FROM Carro ORDER BY Cor";
                        break;
                }
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    lstRetorno = new List<retornoConsultaVeiculos>();
                    while (drLer.Read())
                    {
                        lstRetorno.Add(new retornoConsultaVeiculos()
                        {
                            sCodigo = drLer["vTexto"].ToString(),
                            sTexto = drLer["vTexto"].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de veículos!\n" + ex.Message, "EstacionamentoFacil (109)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lstRetorno;
        }

        /// <summary>
        /// Função para preparar os dados para impressão de extrato de despesas
        /// </summary>
        /// <param name="sQuery">Cláusula para pesquisa</param>
        /// <param name="sFiltro">Filtro para exibição no relatório</param>
        /// <param name="cCarro">Objeto Carro</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_ExtradoDespesas(string sQuery, string sFiltro, carro cCarro)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "DELETE FROM temporarioimpressao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                sSQL = "INSERT INTO temporarioimpressao(indice, texto01, texto02, texto03, texto04, texto05, Data01, Double01, texto14, texto15) " +
                       "SELECT " +
                            "d.Codigo, " +
                            "'" + cCarro.Placa2.Trim() + "' vPlaca, " +
                            "d.Descrição, " +
                            "d.Num_nota, " +
                            "convert(varchar(10),Data,103) vData, " +
                            "convert(varchar,d.valor) vValor, " + //"convert(varchar,FORMAT(d.valor,'C','pt-BR')) vValor, " +
                            "d.Data, " +
                            "d.Valor,  " +
                            "'" + sFiltro + "' vFiltro, " +
                            "(SELECT nome_fantasia FROM empresa) vNomeEmpresa " +
                       "FROM " +
                            "Despesas d " +
                            "	INNER JOIN estacionamento..Despesas_carro dc ON d.Codigo = dc.Cod_despesa " +
                       "WHERE dc.Cod_carro = " + cCarro.Codigo.ToString() + sQuery;
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "UPDATE temporarioimpressao SET texto06 = (" +
                            "SELECT " +
                                "convert(varchar,SUM(d.valor)) " +
                            "FROM Despesas d " +
                                "INNER JOIN Despesas_carro dc ON d.Codigo = dc.Cod_despesa " +
                            "WHERE dc.Cod_carro = " + cCarro.Codigo.ToString() + sQuery +
                        ")";
                /*sSQL = "UPDATE temporarioimpressao SET texto06 = (" +
                            "SELECT " + 
                                "convert(varchar,FORMAT(SUM(d.valor),'C','pt-BR')) " +
                            "FROM Despesas d " + 
                                "INNER JOIN Despesas_carro dc ON d.Codigo = dc.Cod_despesa " +
                            "WHERE dc.Cod_carro = " + cCarro.Codigo.ToString() + sQuery +
                        ")";
                 * */
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de extrato de despesas!\n" + ex.Message, "EstacionamentoFacil (110)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_ExtradoDespesas()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet1 vCust;
            Relatórios.ExtratoDespesas vCrystal;

            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                vCrystal = new Relatórios.ExtratoDespesas();
                vCrystal.SetDataSource(vCust);
                relatorio.ReportSource = vCrystal;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (111)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return relatorio;
        }

        public DataSet impr_ExtradoDespesas(byte bTipo)
        {   
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet vCust;
            
            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                return vCust;
                daLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (111)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }            
        }

        /// <summary>
        /// Função para verificar se existe registro na temporaria
        /// </summary>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool existeRegistroTemp()
        {
            bool bResposta = false;
            string sSQL = "SELECT COUNT(*) vConta FROM temporarioimpressao";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if(drLer.Read()){
                        if (int.Parse(drLer["vConta"].ToString()) > 0)
                            bResposta = true;
                    }
                }
            }
            catch (SqlException ex) { }
            return bResposta;
        }

        /// <summary>
        /// Função para imprimir o total de despesas por período
        /// </summary>
        /// <param name="sQuery">Cláusula SQL para consulta</param>
        /// <param name="sFiltro">Filtro utilizado</param>
        /// <returns>Retorna verdadeiro ou falso, mediante a execução da função</returns>
        public bool impr_TotalDespesas(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "DELETE FROM temporarioimpressao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                sSQL = "INSERT INTO temporarioimpressao(indice, texto01, texto02, texto03, texto04, texto05, Data01, Double01, texto14, texto15) " +
                       "SELECT " +
                            "d.Codigo, " +
                            "car.Placa2, " +
                            "d.Descrição, " +
                            "d.Num_nota, " +
                            "convert(varchar(10),Data,103) vData, " +
                            "convert(varchar,d.valor) vValor, " +//"convert(varchar,FORMAT(d.valor,'C','pt-BR')) vValor, " +
                            "d.Data, " +
                            "d.Valor,  " +
                            "'" + sFiltro + "' vFiltro, " +
                            "(SELECT nome_fantasia FROM empresa) vNomeEmpresa " +
                       "FROM " +
                            "Despesas d " +
                            "	INNER JOIN Despesas_carro dc ON d.Codigo = dc.Cod_despesa " +
                            "   INNER JOIN carro car ON dc.Cod_carro = car.Codigo " + sQuery;
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "UPDATE temporarioimpressao SET texto06 = (" +
                            "SELECT " +
                                "convert(varchar,SUM(d.valor)) " +  //"convert(varchar,FORMAT(SUM(d.valor),'C','pt-BR')) " +
                            "FROM Despesas d " +
                                "INNER JOIN Despesas_carro dc ON d.Codigo = dc.Cod_despesa " +
                                "INNER JOIN carro car ON dc.Cod_carro = car.Codigo " + sQuery +
                        ")";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de extrato de despesas!\n" + ex.Message, "EstacionamentoFacil (112)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_TotalDespesas()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet1 vCust;
            Relatórios.TotalDespesas vCrystal;

            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Texto01, Data01";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                vCrystal = new Relatórios.TotalDespesas();
                vCrystal.SetDataSource(vCust);
                relatorio.ReportSource = vCrystal;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (113)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return relatorio;
        }

        public DataSet impr_TotalDespesas(byte bTipo)
        {            
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet vCust;
            
            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Texto01, Data01";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                return vCust;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (113)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Função para impressão de vendas
        /// </summary>
        /// <param name="sQuery">Cláusula sql para comando</param>
        /// <param name="sFiltro">Filtros para exibição no relatório</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_Vendas(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "DELETE FROM temporarioimpressao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                sSQL = "INSERT INTO temporarioimpressao(indice, texto01, texto02, double01, data01, texto03, texto04, texto05, texto06, memo01, memo02, texto07, texto14, texto15) " +
                       "SELECT " +
                            "v.cod_venda, " +
                            "car.Placa2, " +
                            "(CASE WHEN v.tipo_venda = 0 THEN 'ESTACIONAMENTO' ELSE 'INTERMEDIAÇÃO' END) vTipoVenda, " +
                            "v.valor, " +
                            "v.data_venda, " +
                            "cl2.Nome vVendedor, " +
                            "cl1.Nome vComprador, "+
                            "(CASE v.situacao WHEN 0 THEN 'ABERTO' WHEN 1 THEN 'CONCLUÍDA' WHEN 2 THEN 'CANCELADA' WHEN 3 THEN 'AGUARDANDO FINANCIAMENTO' WHEN 4 THEN 'SUSPENSA' END) vSituacao, " +
                            "v.observacao, " +
                            "STUFF((SELECT ', ' + ltrim(rtrim(vend.Nome)) + ' - ' + convert(varchar,vv.valor_comissao) + ' Sit.: ' + (CASE vv.situacao WHEN 0 THEN 'ABERTA' WHEN 1 THEN 'LANÇADA' WHEN 2 THEN 'CANCELADA' WHEN 3 THEN 'APENAS LANÇADA' END) FROM estacionamento..vendas_vendedor vv INNER JOIN estacionamento..Vendedor vend ON vv.cod_vendedor = vend.Código WHERE vv.cod_venda = v.cod_venda FOR XML PATH('')),1,1,'') AS vComissao, " +//"STUFF((SELECT ', ' + ltrim(rtrim(vend.Nome)) + ' - ' + convert(varchar,FORMAT(vv.valor_comissao,'C','pt-BR')) + ' Sit.: ' + (CASE vv.situacao WHEN 0 THEN 'ABERTA' WHEN 1 THEN 'LANÇADA' WHEN 2 THEN 'CANCELADA' WHEN 3 THEN 'APENAS LANÇADA' END) FROM estancionamento..vendas_vendedor vv INNER JOIN estancionamento..Vendedor vend ON vv.cod_vendedor = vend.Código WHERE vv.cod_venda = v.cod_venda FOR XML PATH('')),1,1,'') AS vComissao, " +
                            "(SELECT CASE WHEN STUFF((SELECT ', ' + convert(varchar,ob.Observacao) + ' (Por: ' + us.nomeusuario + ')' FROM estacionamento..observacao ob INNER JOIN estacionamento..Usuarios us ON ob.cod_usuario = us.cod_usuario WHERE ob.codigo = v.cod_venda AND ob.tipo = 2 FOR XML PATH('')),1,1,'') IS NULL THEN '' ELSE STUFF((SELECT ', - ' + convert(varchar,ob.Observacao) + ' (Por: ' + RTRIm(ltrim(us.nomeusuario)) + ')' FROM estacionamento..observacao ob INNER JOIN estacionamento..Usuarios us ON ob.cod_usuario = us.cod_usuario WHERE ob.codigo = v.cod_venda AND ob.tipo = 2 FOR XML PATH('')),1,1,'') END) AS vObservacao, " +
                            "CONVERT(nvarchar(20),v.data_venda,103) + ' ' + CONVERT(nvarchar(20),v.data_venda,108) vDataVenda, " +
                            "'" + sFiltro + "' vFiltro, " +
                            "(SELECT nome_fantasia FROM empresa) vNomeEmpresa " +
                        "FROM " +
                            "vendas v " +
                                "INNER JOIN Cliente cl1 ON v.cod_cliente_comprador = cl1.Codigo "+
                                "INNER JOIN Cliente cl2 ON v.cod_cliente_vendedor = cl2.Codigo " +
                                "INNER JOIN Carro car   ON v.cod_carro = car.Codigo " + sQuery;
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                sSQL = "UPDATE temporarioimpressao SET texto08 = (" +
                            "SELECT " +
                                "convert(varchar,sum(t.double01)) " + //"convert(varchar,FORMAT(SUM(t.double01),'C','pt-BR')) " +
                            "FROM temporarioimpressao t " +
                        ")";
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de extrato de despesas!\n" + ex.Message, "EstacionamentoFacil (114)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_Vendas()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet1 vCust;
            Relatórios.Vendas vCrystal;

            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                vCrystal = new Relatórios.Vendas();
                vCrystal.SetDataSource(vCust);
                relatorio.ReportSource = vCrystal;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (115)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return relatorio;
        }

        public DataSet impr_Vendas(byte bTipo)
        {
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet vCust;
            
            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                return vCust;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (115)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        public bool controleVersao()
        {
            bool bResposta = true;
            long lVersao = 1001;
            SqlCommand cmComando;
            SqlDataReader drLer;
            string sSQL = "SELECT * FROM Controle WHERE Tela = 'VERSAO'";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        lVersao = long.Parse(drLer["Valor"].ToString());
                    }                    
                }                
                drLer.Dispose();
                drLer.Close();
                cmComando.Dispose();
                bResposta = atualizarVersao(lVersao);
            }
            catch (SqlException ex) {
                System.Windows.Forms.MessageBox.Show("Erro ao atualizar controle de versão!\n" + ex.Message, "EstacionamentoFacil (116a)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false; 
            }
            return bResposta;
        }

        private bool atualizarVersao(long lVersao)
        {
            bool bResposta = true;
            SqlCommand cmComando;
            string sSQL = "";
            try
            {
                if (lVersao == 1001)
                {
                    sSQL = "ALTER TABLE Cliente ADD TipoPessoa        INT          NOT NULL DEFAULT 0";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD DtNascimento      DATETIME     NOT NULL DEFAULT '00:00:00'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD DtCadastro        DATETIME     NOT NULL DEFAULT '00:00:00'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD DtRenovacaoSeguro DATETIME     NOT NULL DEFAULT '00:00:00'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD Profissao         NVARCHAR(50)";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD Status            INT          NOT NULL DEFAULT 0";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD Sexo              INT          NOT NULL DEFAULT 0";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD EstadoCivil       NVARCHAR(50)";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD FaixaSalarial     INT          NOT NULL DEFAULT 0";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD CNH               NVARCHAR(50) NOT NULL DEFAULT ''";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD ValidadeCNH       DATETIME     NOT NULL DEFAULT '00:00:00'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD CategoriaCNH      NVARCHAR(5)  NOT NULL DEFAULT ''";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "ALTER TABLE Cliente ADD DtPrimeiraCNH     DATETIME     NOT NULL DEFAULT '00:00:00'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "UPDATE Cliente SET TipoPessoa = 0, DtNascimento = '00:00:00', DtCadastro = CONVERT(DATETIME,'20/04/2015',103), DtRenovacaoSeguro = '00:00:00', Profissao = '', Status = 0, EstadoCivil = '', FaixaSalarial = 0, CNH = '', ValidadeCNH = '00:00:00', CategoriaCNH = '', DtPrimeiraCNH = '00:00:00'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "INSERT INTO Controle(Tela, Valor) VALUES('VERSAO','1002')";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "CREATE TABLE ContaCartao ( " +
                                "CodContaCartao INT IDENTITY NOT NULL, " +
                                "CodCliente     INT NOT NULL,          " +
                                "Tipo           INT,                   " +
                                "Numero         NVARCHAR(50) NOT NULL, " +
                                "Bandeira       NVARCHAR(10) NOT NULL, " +
                                "NomeBanco      NVARCHAR(50) NOT NULL, " +
                                "Agencia        NVARCHAR(4)  NOT NULL, " +
                                "NumConta       NVARCHAR(50) NOT NULL, " +
                                "CPF            NVARCHAR(15) NOT NULL, " +
                                "CNPJ           NVARCHAR(20) NOT NULL, " +
                                "OBS            TEXT                   " +
                            ")";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "INSERT INTO auditoria_operacao(descricao) VALUES('Exluir conta/cartão'),('Inserir conta/cartão')";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                }
                if (lVersao == 1002)
                {
                    sSQL = "INSERT INTO auditoria_operacao(descricao) VALUES('Exluir cliente'),('Inserir cliente')";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "UPDATE Controle SET Valor = '1003' WHERE Tela = 'VERSAO'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                }
                if (lVersao == 1003)
                {
                    sSQL = "ALTER TABLE Empresa ADD TipoRelatorio INT NOT NULL DEFAULT 0";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();

                    sSQL = "UPDATE Controle SET Valor = '1004' WHERE Tela = 'VERSAO'";
                    cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                    cmComando.ExecuteNonQuery();
                    cmComando.Dispose();
                }                
            }
            catch (SqlException ex) {
                System.Windows.Forms.MessageBox.Show("Erro ao atualizar controle de versão!\n" + ex.Message, "EstacionamentoFacil (116b)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bResposta = false;
            }
            return bResposta;
        }

        /// <summary>
        /// Função para impressão de comissao
        /// </summary>
        /// <param name="sQuery">Cláusula sql para comando</param>
        /// <param name="sFiltro">Filtros para exibição no relatório</param>
        /// <returns>Retorna verdadeiro ou falso mediante a execução da função</returns>
        public bool impr_Comissao(string sQuery, string sFiltro)
        {
            bool bResposta = false;
            SqlCommand cmComando;
            string sSQL = "DELETE FROM temporarioimpressao";
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();
                sSQL = "INSERT INTO temporarioimpressao(Indice, texto01, texto02, texto03, texto04, texto05, double01, data01, texto14, texto15) " +
                       "SELECT " +
                            "(SELECT CASE WHEN vend.cod_venda < 10 THEN REPLICATE('0',4) WHEN vend.cod_venda > 9 and vend.cod_venda < 100 THEN	 REPLICATE('0',3) WHEN vend.cod_venda > 99 and vend.cod_venda < 1000 THEN	 REPLICATE('0',2) WHEN vend.cod_venda > 999 and vend.cod_venda < 10000 THEN	 REPLICATE('0',1) END) + CONVERT(VARCHAR,vend.cod_venda ) + '/' + CONVERT(VARCHAR,YEAR(vend.data_venda)) vCodVenda, "+
                            "v.Nome, " +
                            "car.Placa2, " +
                            "(SELECT CASE vv.situacao WHEN 0 THEN 'ABERTA' WHEN 1 THEN 'LANÇADA' WHEN 2 THEN 'CANCELADA' WHEN 3 THEN 'APENAS LANÇADA' END) vSituacao, " +
                            "CONVERT(varchar,vv.valor_comissao) vValorComissao, " +//"CONVERT(varchar,FORMAT(vv.valor_comissao,'C','pt-BR')) vValorComissao, " +
                            "CONVERT(nvarchar(20),vend.data_venda,103) + ' ' + CONVERT(nvarchar(20),vend.data_venda,108) vDataVenda, " +
                            "vv.valor_comissao, " +
                            "vend.data_venda, " +
                            "'" + sFiltro +"' vFiltro, " +
                            "(SELECT nome_fantasia FROM empresa) vNomeEmpresa " +
                       "FROM vendas_vendedor vv " +
                            "INNER JOIN Vendedor v ON vv.cod_vendedor = v.Código " +
                            "INNER JOIN vendas vend ON vv.cod_venda = vend.cod_venda " +
                            "INNER JOIN Carro car ON vend.cod_carro = car.Codigo " + sQuery; 
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                cmComando.ExecuteNonQuery();
                cmComando.Dispose();

                bResposta = true;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de extrato de despesas!\n" + ex.Message, "EstacionamentoFacil (116)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        /// <summary>
        /// Função para retornar o relatório para impressão
        /// </summary>
        /// <returns></returns>
        public CrystalDecisions.Windows.Forms.CrystalReportViewer impr_Comissao()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer relatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet1 vCust;
            Relatórios.Comissao vCrystal;

            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet1();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                vCrystal = new Relatórios.Comissao();
                vCrystal.SetDataSource(vCust);
                relatorio.ReportSource = vCrystal;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (117)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return relatorio;
        }

        public DataSet impr_Comissao(byte bTipo)
        {   
            SqlCommand cmComando;
            SqlDataAdapter daLer;
            DataSet vCust = new DataSet();
            vCust = null;
            string sSQL = "SELECT * FROM temporarioimpressao ORDER BY Data01 DESC";
            try
            {
                cmComando = conexaoPrincipal.CreateCommand();
                cmComando.CommandText = sSQL;
                daLer = new SqlDataAdapter();
                daLer.SelectCommand = cmComando;
                vCust = new DataSet();
                vCust.Clear();
                daLer.Fill(vCust, "temporarioimpressao");
                return vCust;
                daLer.Dispose();
                cmComando.Dispose();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados tela de impressão!\n" + ex.Message, "EstacionamentoFacil (117)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }            
        }

        /// <summary>
        /// Função para verificar se o último backup realizado está dentro de 30 dias
        /// </summary>
        /// <returns>Retorna Verdadeiro caso não tenha backup a 30 dias e False para backup realizado recentemente</returns>
        public bool verificarUltimoBackup()
        {
            bool bResposta = true;
            string sSQL = "SELECT COUNT(*) vConta FROM Auditoria WHERE Operacao = 14 AND data_operacao BETWEEN DATEADD(day,-30,GETDATE()) AND GETDATE()";
            SqlCommand cmComando;
            SqlDataReader drLer;
            try
            {
                cmComando = new SqlCommand(sSQL, conexaoPrincipal);
                drLer = cmComando.ExecuteReader();
                if (drLer.HasRows)
                {
                    if (drLer.Read())
                    {
                        if (int.Parse(drLer["vConta"].ToString()) == 0)
                        {
                            bResposta = false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("Erro ao buscar dados de backup!\n" + ex.Message, "EstacionamentoFacil (118)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return bResposta;
        }

        public bool limparBancoDados()
        {
            bool bResposta = false;


            return bResposta;
        }

        public void mensagemChaveEstrangeira(string sTexto)
        {
            System.Windows.Forms.MessageBox.Show("Exclusão não permitida.\nExistem registros relacionados com este(a) " + sTexto + "!!!", "EstacionamentoFacil (12a)", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

    }
}
