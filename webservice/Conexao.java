/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package br.com.process.w2.webservice;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author Junior
 */
public class Conexao {
    
     private static final String driver = "org.postgresql.Driver";
     private static final String SCHEMA_DEFAULT = "homologa";
     
    public Connection getConnection() {
        try {
            Class.forName(driver);
            Connection con = DriverManager.getConnection(
          "jdbc:postgresql://s86xrr.hospedagemweb.net:7159/Editorweb", "Process", "pr2106win");
            con.createStatement().execute( String.format("set search_path=%s", SCHEMA_DEFAULT));
            return con;
        } catch (SQLException e) {
            throw new RuntimeException(e);
        } catch (ClassNotFoundException e){
            throw new RuntimeException(e);
        }
    }
}
