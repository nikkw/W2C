/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package br.com.process.w2.webservice;

/**
 *
 * @author Junior
 */
public class SQL {

    // SELECT PARA LOGIN DO USUARIO
    public static final String BUSCA_USUARIO = "SELECT * FROM accounts where (acc_email='%s' or acc_login='%s') "; //and acc_password='%s'
    // SELECT PARA CARREGAR OS MENUS
    public static final String BUSCA_MENUS = "SELECT * from dados_documentos(%d, '%s') order by areanome, gruponome, subnome";
    // SELECT PARA BUSCAR O DOCUMENTOS BASEADO NO SUBGRUPO
    public static final String BUSCA_DOCUMENTO_SUBGRUPO = "SELECT * FROM documents "
            + "inner join area on (area_id=doc_id_area) "
            + "inner join groups on (grp_id= doc_id_group) "
            + "inner join subgroups on (sgrp_id = doc_id_subgroup) "
            + "where doc_delete_date is null "
            + "and doc_id_subgroup=%s "
            + "and doc_active=true "
            + "and doc_id_account=%d";
    // SELECT PARA BUSCAR DOCUMENTOS BASEADO NA STRING PASSADA NO INPUT DE BUSCA
    public static final String BUSCA_DOCUMENTO_BUSCA = "select * from documents "
            + "inner join area on (area_id=doc_id_area) "
            + "inner join groups on (grp_id= doc_id_group) "
            + "inner join subgroups on (sgrp_id = doc_id_subgroup) "
            + "where doc_id_account=%d "
            + "and sp_filtra_acentos(doc_name) "
            + "like sp_filtra_acentos('%%%s%%') "
            + "or sp_filtra_acentos(doc_observation) "
            + "like sp_filtra_acentos('%%%s%%')";
    // SELECT PARA BUSCAR DOCUMENTOS DA LIXEIRA
    public static final String BUSCA_DOCUMENTO_LIXEIRA = "select * from documents "
            + "inner join area on (area_id=doc_id_area) "
            + "inner join groups on (grp_id= doc_id_group) "
            + "inner join subgroups on (sgrp_id = doc_id_subgroup) "
            + "where doc_active=true and doc_delete_date is not null "
            + "and (doc_id_account is null or doc_id_account=%d)";
    // SELECT PARA BUSCAR OS DOCUMENTOS RECENTES
    public static final String BUSCA_DOCUMENTOS_RECENTES = "select *, coalesce(doc_observation, '''')  from documents "
            + "inner join area on (area_id=doc_id_area) "
            + "inner join groups on (grp_id= doc_id_group) "
            + "inner join subgroups on (sgrp_id = doc_id_subgroup) "
            + "where doc_delete_date is null "
            + "and doc_active=true "
            + "and doc_id_account=%d "
            + "order by doc_create_date desc limit 20";
    // SELECT PARA BUSCA DOCUMENTO
    public static final String BUSCA_DOCUMENTO_ID = "select * from documents "
            + "inner join area on (area_id=doc_id_area) "
            + "inner join groups on (grp_id= doc_id_group) "
            + "inner join subgroups on (sgrp_id = doc_id_subgroup) "
            + "where doc_id=%d and doc_id_account=%d";
    // SELECT PARA BUSCAR AS INFORMAÇÕES DO BANCO ABCDOC
    public static final String BUSCA_BANCO_ABCDOC = "select * from sys_cloud order by port limit 1";
    

    ////////////////////////// UPDATE //////////////////////////
    // 
    public static final String UPDATE_RESTAURAR = "update documents set doc_delete_date=null where doc_id=? and doc_id_account=?";
    // 
    public static final String UPDATE_EXCLUSAO = "update documents set doc_delete_date=? where doc_id=? and doc_id_account=?";
    // 
    public static final String UPDATE_EXCLUSAO_DEFINITIVA = "update documents set doc_active=false where doc_id=? and doc_id_account=?";
    //
    public static final String UPDATE_ALTERAR_EMAIL = "update accounts set acc_email=? where acc_id=?";
    //
    public static final String UPDATE_ALTERAR_SENHA = "update accounts set acc_password=? where acc_id=?";
    //
    public static final String UPDATE_EDITAR_GRUPO = "update groups set grp_name=? where grp_id=?";
    //
    public static final String UPDATE_EDITAR_SUB = "update subgroups set grp_name=? where grp_id=?";

    ////////////////////////// INSERT //////////////////////////
    //
    public static final String INSERT_NOVO_DOCUMENTO = "INSERT INTO documents"
            + "(doc_id_area, doc_id_group, doc_id_subgroup, "
            + "doc_id_account, doc_id_area_account, doc_hash, doc_name, doc_observation, "
            + "doc_pages, doc_wordversion, doc_format, doc_identifier) "
            + "values (?,?,?,?,?,?,?,?.alinha_texto(?, 50),?,?,?,?)";
    //
    public static final String INSERT_NOVO_GRUPO = "INSERT INTO groups(grp_id_area, grp_name, grp_group_accounts) "
            + "values (?, ?, ?)";
    //
    public static final String INSERT_NOVO_SUBGRUPO = "INSERT INTO subgroups(sgrp_id_group, sgrp_name) "
            + "values (?, ?)";

}
