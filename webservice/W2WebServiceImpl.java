/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.process.w2.webservice;

import br.com.process.w2.classes.Accounts;
import br.com.process.w2.classes.BancoAbcDoc;
import br.com.process.w2.classes.Documento;
import br.com.process.w2.classes.Menu;
import br.com.process.w2.menus.Group;
import br.com.process.w2.menus.SubGroup;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.ejb.Stateless;

/**
 *
 * @author Junior
 */
@WebService(serviceName = "W2WebService")
@Stateless()
public class W2WebServiceImpl implements W2WebService {

    private ResultSet rs = null;
    private PreparedStatement stmt = null;
    private Connection con = null;
    private static final String TEMPLATE_BUSCAS = "homologa";

    /**
     * Operação de Web service
     *
     * @param login
     * @param senha
     * @return
     */
    @WebMethod(operationName = "getAccount")
    @Override
    public Accounts getAccount(@WebParam(name = "login") String login, @WebParam(name = "senha") String senha) {
        con = new Conexao().getConnection();
        Accounts conta = null;
        try {
            stmt = con.prepareStatement(String.format(SQL.BUSCA_USUARIO, login, login)); //, senha
            rs = stmt.executeQuery();
            while (rs.next()) {
                conta = new Accounts(rs.getInt("acc_id"), rs.getString("acc_email"), rs.getString("acc_password"), rs.getString("acc_fullname"), rs.getString("acc_cpf"), rs.getBoolean("acc_active"), rs.getInt("acc_menutype"), rs.getBoolean("acc_opendocument"), rs.getString("acc_dirdownload"), rs.getBoolean("acc_sendpublic"), rs.getTimestamp("acc_createdate"), rs.getTimestamp("acc_deletedate"), rs.getString("acc_login"));
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return conta;
    }

    @WebMethod(operationName = "getMenu")
    @Override
    public List<Menu> getMenu(@WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        List<Menu> listaMenu = new ArrayList<>();
        try {
            stmt = con.prepareStatement(String.format(SQL.BUSCA_MENUS, Hash.reverse(hash), TEMPLATE_BUSCAS));
            rs = stmt.executeQuery();
            while (rs.next()) {
                Menu menu = new Menu(rs.getInt("areaid"), rs.getLong("subid"), rs.getLong("grupoid"), rs.getString("areanome"), rs.getString("gruponome"), rs.getString("subnome"), rs.getInt("qtdegrupo"), rs.getInt("qtdesubgrupo"), rs.getBoolean("areaedit"));
                listaMenu.add(menu);
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return listaMenu;
    }

    /**
     * Operação de Web service
     *
     * @param codigoSub
     * @param hash
     * @return
     */
    @WebMethod(operationName = "getListaDocumentos")
    @Override
    public List<Documento> getListaDocumentos(@WebParam(name = "codigoSub") long codigoSub, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        List<Documento> listaDocumentos = new ArrayList<>();
        try {
            stmt = con.prepareStatement(String.format(SQL.BUSCA_DOCUMENTO_SUBGRUPO, codigoSub, Hash.reverse(hash)));
            rs = stmt.executeQuery();
            while (rs.next()) {
                Documento documento = new Documento(rs.getLong("doc_id"), rs.getInt("doc_id_area"), rs.getLong("doc_id_group"), rs.getLong("doc_id_subgroup"), rs.getInt("doc_id_account"), rs.getInt("doc_id_area_account"), rs.getString("doc_hash"), rs.getString("doc_name"), rs.getString("doc_observation"), rs.getInt("doc_pages"), rs.getTimestamp("doc_create_date"), rs.getTimestamp("doc_update_date"), rs.getTimestamp("doc_delete_date"), rs.getBoolean("doc_active"), rs.getInt("doc_wordversion"), rs.getString("doc_format"), rs.getString("doc_identifier"));
                listaDocumentos.add(documento);
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return listaDocumentos;
    }

    /**
     * Operação de Web service
     *
     * @param busca
     * @param hash
     * @return
     */
    @WebMethod(operationName = "getListaBusca")
    @Override
    public List<Documento> getListaBusca(@WebParam(name = "busca") String busca, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        List<Documento> listaDocumentos = new ArrayList<>();
        try {
            String sql = String.format(SQL.BUSCA_DOCUMENTO_BUSCA, Hash.reverse(hash), busca, busca);

            stmt = con.prepareStatement(sql);
            rs = stmt.executeQuery();
            while (rs.next()) {
                Documento documento = new Documento(rs.getLong("doc_id"), rs.getInt("doc_id_area"), rs.getLong("doc_id_group"), rs.getLong("doc_id_subgroup"), rs.getInt("doc_id_account"), rs.getInt("doc_id_area_account"), rs.getString("doc_hash"), rs.getString("doc_name"), rs.getString("doc_observation"), rs.getInt("doc_pages"), rs.getTimestamp("doc_create_date"), rs.getTimestamp("doc_update_date"), rs.getTimestamp("doc_delete_date"), rs.getBoolean("doc_active"), rs.getInt("doc_wordversion"), rs.getString("doc_format"), rs.getString("doc_identifier"));
                listaDocumentos.add(documento);
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return listaDocumentos;
    }

    @WebMethod(operationName = "getListaLixeira")
    @Override
    public List<Documento> getListaLixeira(@WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        List<Documento> listaDocumentos = new ArrayList<>();
        try {
            stmt = con.prepareStatement(String.format(SQL.BUSCA_DOCUMENTO_LIXEIRA, Hash.reverse(hash)));
            rs = stmt.executeQuery();
            while (rs.next()) {
                Documento documento = new Documento(rs.getLong("doc_id"), rs.getInt("doc_id_area"), rs.getLong("doc_id_group"), rs.getLong("doc_id_subgroup"), rs.getInt("doc_id_account"), rs.getInt("doc_id_area_account"), rs.getString("doc_hash"), rs.getString("doc_name"), rs.getString("doc_observation"), rs.getInt("doc_pages"), rs.getTimestamp("doc_create_date"), rs.getTimestamp("doc_update_date"), rs.getTimestamp("doc_delete_date"), rs.getBoolean("doc_active"), rs.getInt("doc_wordversion"), rs.getString("doc_format"), rs.getString("doc_identifier"));
                listaDocumentos.add(documento);
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return listaDocumentos;
    }

    @WebMethod(operationName = "getListaRecentes")
    @Override
    public List<Documento> getListaRecentes(@WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        List<Documento> listaDocumentos = new ArrayList<>();
        try {
            stmt = con.prepareStatement(String.format(SQL.BUSCA_DOCUMENTOS_RECENTES, Hash.reverse(hash)));
            rs = stmt.executeQuery();
            while (rs.next()) {
                Documento documento = new Documento(rs.getLong("doc_id"), rs.getInt("doc_id_area"), rs.getLong("doc_id_group"), rs.getLong("doc_id_subgroup"), rs.getInt("doc_id_account"), rs.getInt("doc_id_area_account"), rs.getString("doc_hash"), rs.getString("doc_name"), rs.getString("doc_observation"), rs.getInt("doc_pages"), rs.getTimestamp("doc_create_date"), rs.getTimestamp("doc_update_date"), rs.getTimestamp("doc_delete_date"), rs.getBoolean("doc_active"), rs.getInt("doc_wordversion"), rs.getString("doc_format"), rs.getString("doc_identifier"));
                listaDocumentos.add(documento);
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return listaDocumentos;
    }

    @WebMethod(operationName = "getDocumento")
    @Override
    public Documento getDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        Documento documento = null;
        try {
            stmt = con.prepareStatement(String.format(SQL.BUSCA_DOCUMENTO_ID, docId, Hash.reverse(hash)));
            rs = stmt.executeQuery();
            while (rs.next()) {
                documento = new Documento(rs.getLong("doc_id"), rs.getInt("doc_id_area"), rs.getLong("doc_id_group"), rs.getLong("doc_id_subgroup"), rs.getInt("doc_id_account"), rs.getInt("doc_id_area_account"), rs.getString("doc_hash"), rs.getString("doc_name"), rs.getString("doc_observation"), rs.getInt("doc_pages"), rs.getTimestamp("doc_create_date"), rs.getTimestamp("doc_update_date"), rs.getTimestamp("doc_delete_date"), rs.getBoolean("doc_active"), rs.getInt("doc_wordversion"), rs.getString("doc_format"), rs.getString("doc_identifier"));
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return documento;
    }

    @WebMethod(operationName = "getAbcDoc")
    @Override
    public BancoAbcDoc getAbcDoc() {
        con = new Conexao().getConnection();
        BancoAbcDoc abcDoc = null;
        try {
            stmt = con.prepareStatement(String.format(SQL.BUSCA_BANCO_ABCDOC));
            rs = stmt.executeQuery();
            while (rs.next()) {
                abcDoc = new BancoAbcDoc(rs.getString("ip"), rs.getInt("port"), rs.getString("application"), rs.getString("userr"), rs.getString("password"));
            }

        } catch (SQLException e) {
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return abcDoc;
    }

    //UPDATE
    @WebMethod(operationName = "setRestaurarDocumento")
    @Override
    public int setRestaurarDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.UPDATE_RESTAURAR);
            stmt.setLong(1, docId);
            stmt.setLong(2, Integer.parseInt(hash));
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "setExcluirDocumento")
    @Override
    public int setExcluirDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.UPDATE_EXCLUSAO);
            stmt.setLong(1, docId);
            stmt.setLong(2, Integer.parseInt(hash));
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "setExclusaoDefinitivaDocumento")
    @Override
    public int setExclusaoDefinitivaDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.UPDATE_EXCLUSAO_DEFINITIVA);
            stmt.setLong(1, docId);
            stmt.setLong(2, Integer.parseInt(hash));
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "setGrupo")
    @Override
    public int setGrupo(@WebParam(name = "grupo") Group grupo, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.UPDATE_EDITAR_GRUPO);
            stmt.setString(1, grupo.getNome());
            stmt.setLong(2, grupo.getId());
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "setSub")
    @Override
    public int setSub(@WebParam(name = "sub") SubGroup sub, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.UPDATE_EDITAR_SUB);
            stmt.setString(1, sub.getNome());
            stmt.setLong(2, sub.getId());
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "setEmail")
    @Override
    public int setEmail(@WebParam(name = "email") String email, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.UPDATE_ALTERAR_EMAIL);
            stmt.setString(1, email);
            stmt.setLong(2, Integer.parseInt(hash));
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "setSenha")
    @Override
    public int setSenha(@WebParam(name = "senha") String senha, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.UPDATE_ALTERAR_SENHA);
            stmt.setString(1, senha);
            stmt.setLong(2, Integer.parseInt(hash));
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "newDocumento")
    @Override
    public int newDocumento(@WebParam(name = "documento") Documento documento, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.INSERT_NOVO_DOCUMENTO);
            stmt.setInt(1, documento.getAreaid());
            stmt.setLong(2, documento.getGrupoid());
            stmt.setLong(3, documento.getSubid());
            stmt.setInt(4, documento.getIdacc());
            stmt.setInt(5, documento.getAreaAccount());
            stmt.setString(6, documento.getHash());
            stmt.setString(7, documento.getName());
            stmt.setString(8, TEMPLATE_BUSCAS);
            stmt.setString(9, documento.getObservacao());
            stmt.setInt(10, documento.getPages());
            stmt.setInt(11, documento.getWordversion());
            stmt.setString(12, documento.getFormat());
            stmt.setString(13, documento.getIdentifier());
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "newGrupo")
    @Override
    public int newGrupo(@WebParam(name = "grupo") Group grupo, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.INSERT_NOVO_GRUPO);
            stmt.setInt(1, grupo.getIdArea());
            stmt.setString(2, grupo.getNome());
            stmt.setInt(3, Hash.reverse(hash));
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

    @WebMethod(operationName = "newSubGrupo")
    @Override
    public int newSubGrupo(@WebParam(name = "subGrupo") SubGroup subGrupo, @WebParam(name = "hash") String hash) {
        con = new Conexao().getConnection();
        int retorno = 0;
        try {
            con.setAutoCommit(false);
            stmt = con.prepareStatement(SQL.INSERT_NOVO_SUBGRUPO);
            stmt.setLong(1, subGrupo.getIdGroup());
            stmt.setString(2, subGrupo.getNome());
            retorno = stmt.executeUpdate();
            con.commit();
        } catch (SQLException e) {
            retorno = 0;
            System.out.println(e.getMessage());
        } finally {
            try {
                if (con != null) {
                    con.close();
                }
                if (stmt != null) {
                    stmt.close();
                }
                if (rs != null) {
                    rs.close();
                }
            } catch (SQLException e) {
                System.out.println(e.getMessage());
            }
        }
        return retorno;
    }

}
