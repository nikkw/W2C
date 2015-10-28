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
import java.util.List;
import javax.jws.WebMethod;
import javax.jws.WebParam;


/**
 *
 * @author Junior
 */
public interface W2WebService {

    @WebMethod(operationName = "getAccount")
    public Accounts getAccount(@WebParam(name = "login") String login, @WebParam(name = "senha") String senha);
    
    @WebMethod(operationName = "getMenu")
    public List<Menu> getMenu(@WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "getListaDocumentos")
    public List<Documento> getListaDocumentos(@WebParam(name = "codigoSub") long codigoSub, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "getListaBusca")
    public List<Documento> getListaBusca(@WebParam(name = "busca") String busca, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "getListaLixeira")
    public List<Documento> getListaLixeira(@WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "getListaRecentes")
    public List<Documento> getListaRecentes(@WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "getDocumento")
    public Documento getDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "getAbcDoc")
    public BancoAbcDoc getAbcDoc();
    
    
    @WebMethod(operationName = "setRestaurarDocumento")
    public int setRestaurarDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "setExcluirDocumento")
    public int setExcluirDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "setExclusaoDefinitivaDocumento")
    public int setExclusaoDefinitivaDocumento(@WebParam(name = "docId") long docId, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "setGrupo")
    public int setGrupo(@WebParam(name = "grupo") Group grupo, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "setSub")
    public int setSub(@WebParam(name = "sub") SubGroup sub, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "setEmail")
    public int setEmail(@WebParam(name = "email") String email, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "setSenha")
    public int setSenha(@WebParam(name = "senha")String senha, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "newDocumento")
    public int newDocumento(@WebParam(name = "documento") Documento documento, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "newGrupo")
    public int newGrupo(@WebParam(name = "grupo") Group grupo, @WebParam(name = "hash") String hash);
    
    @WebMethod(operationName = "newSubGrupo")
    public int newSubGrupo(@WebParam(name = "subGrupo") SubGroup subGrupo, @WebParam(name = "hash") String hash);
    
}
