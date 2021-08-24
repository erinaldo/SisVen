package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.TextView;

public class Menu extends AppCompatActivity {
Intent wActividad=null;
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);
        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_HIDDEN);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
        android.support.v7.app.ActionBar wBarraMenu = getSupportActionBar();
        wBarraMenu.setTitle("Menú");
        wBarraMenu.setSubtitle("M-00");
        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setIcon(R.mipmap.ic_launcher);

        TextView wMensajeBienvenida = (TextView) findViewById(R.id.mMenuPrincipal);
        String wNombreUsr = ((variables_gloabales) this.getApplication()).getNombreUsuarioActual();
        wMensajeBienvenida.setText("Bienvenido " + wNombreUsr);
    }
    public void Ventas(View v)
    {
        LanzarActividad(menu_ventas.class,true);
    }
    public void Anulaciones(View v)
    {
        LanzarActividad(anulaciones.class,true);
    }
    public void Correlativos(View v)
    {
        LanzarActividad(correlativos.class,true);
    }
    public void Precios(View v)
    {
        LanzarActividad(precio.class,true);
    }
    public void Clientes(View v)
    {
        LanzarActividad(clientes.class,true);
    }
    public void Consultas(View v)
    {
        LanzarActividad(consultas.class,true);
    }
    public void EnvioDocumentos(View v)
    {
        LanzarActividad(GenerarPdf.class,true);
    }
    public void Salir(View v)
    {
        LanzarActividad(login.class,false);
    }
    public void LanzarActividad(Class wClase,boolean wInternet)
    {
        if (wInternet)
        {
            if (!ValidarInternet()) {
                return;
            }
        }
        wActividad = new Intent(Menu.this,wClase);
        startActivity(wActividad);
        finish();
    }
    public boolean ValidarInternet()
    {
        if (!verificaConexion(Menu.this)) {
            AlertDialog.Builder wMensaje = new AlertDialog.Builder(Menu.this);
            wMensaje.setMessage("El dispositivo no tiene acceso a Internet");
            wMensaje.setTitle("Advertencia");
            wMensaje.setIcon(R.drawable.advertencia64);
            wMensaje.setNegativeButton("Aceptar", null);
            wMensaje.create();
            wMensaje.show();
            return false;
        }
        return true;
    }
    public static boolean verificaConexion(Context wContext) {
        boolean bConectado = false;
        ConnectivityManager connec = (ConnectivityManager) wContext
                .getSystemService(Context.CONNECTIVITY_SERVICE);
        // No sólo wifi, también GPRS
        NetworkInfo[] redes = connec.getAllNetworkInfo();
        // este bucle debería no ser tan ñapa
        for (int i = 0; i < 2; i++) {
            // ¿Tenemos conexión? ponemos a true
            if (redes[i].getState() == NetworkInfo.State.CONNECTED) {
                bConectado = true;
            }
        }
        return bConectado;
    }
}