package wikets.mypos;
import android.app.Application;

/**
 * Created by Miguel on 04-05-2018.
*/


public class variables_gloabales extends Application {

    /////// DECLARACION DE VARIABLES GLOBALES USUARIO....

    public String UsuarioActual;
    public String NombreUsuarioActual;
    public String RutUsuarioActual;
    public String LocalUsuarioActual;
    public String URLWS="http://wikets.cl/MyPos/";
    public Integer DTE_Neto;
    private Integer DTE_Iva;
    private Integer DTE_Total;

    public String Descripcion_Articulo;

    /////////////   DATOS DEL USUARIO

    public String getUsuarioActual() {
        return UsuarioActual;
    }

    public void setUsuarioActual(String wUsuario) {
        this.UsuarioActual = wUsuario;
    }


    public String getNombreUsuarioActual() {
        return NombreUsuarioActual;
    }

    public void setNombreUsuarioActual(String wNombre) {
        this.NombreUsuarioActual = wNombre;
    }


    public String getRutUsuarioActual() {
        return RutUsuarioActual;
    }

    public void setRutUsuarioActual(String wRut) {
        this.RutUsuarioActual = wRut;
    }


    public String getLocalUsuarioActual() {
        return LocalUsuarioActual;
    }

    public void setLocalUsuarioActual(String wLocal) {
        this.LocalUsuarioActual = wLocal;
    }
    public String getURLWS() {
        return URLWS;
    }

    public void setURLWS(String wUrlWS) {
        this.URLWS = wUrlWS;
    }

    /////////////   DATOS DEL DTE

    public Integer getDTE_Neto() {
        return DTE_Neto;
    }

    public void setDTE_Neto(Integer wDTE_Neto) {
        this.DTE_Neto = wDTE_Neto;
    }


    public String getDescripcion_Articulo() {
        return Descripcion_Articulo;
    }

    public void setDescripcion_Articulo(String wDescripcion) {
        this.Descripcion_Articulo = wDescripcion;
    }



}