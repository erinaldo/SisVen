package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.graphics.Paint;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.github.pinball83.maskededittext.MaskedEditText;

import org.json.JSONException;
import org.json.JSONObject;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;
import static wikets.mypos.constantes.FIRST_COLUMN;
import static wikets.mypos.constantes.SECOND_COLUMN;
import static wikets.mypos.constantes.THIRD_COLUMN;
import static wikets.mypos.constantes.FOURTH_COLUMN;

import static wikets.mypos.constantes.FIVE_COLUMN;
import static wikets.mypos.constantes.SIX_COLUMN;
import static wikets.mypos.constantes.SEVEN_COLUMN;
import static wikets.mypos.constantes.EIGHT_COLUMN;
import static wikets.mypos.constantes.NINE_COLUMN;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class venta_detallada extends AppCompatActivity {
    ArrayList<String> movies;

    private Integer DTE_Neto;
    private Integer DTE_Iva;
    private Integer DTE_Iva_Unitario;
    private Integer DTE_Total;
    private Integer DTE_TotalT;
    private Integer DTE_IvaT;
    private Integer DTE_NetoT;
    private String CAF;
    private int cantidaddelarticulo;
    private String Descripcion_Articulo;
    private String Descripcion_Corta;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.venta_detallada);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Documento Electrónico");
        actionbar.setSubtitle("MV-02");

        DTE_Neto = 0;
        DTE_Iva = 0;
        DTE_Total = 0;
        DTE_IvaT = 0;
        DTE_TotalT = 0;
        DTE_NetoT = 0;

        final Spinner tiposdocs = (Spinner) findViewById(R.id.spinnertipo);
        final Spinner formasdepago = (Spinner) findViewById(R.id.spinnerpago);

        Button botonemitirdoc = (Button) findViewById(R.id.bEmitirDoc);
        Button botonvolver = (Button) findViewById(R.id.bVolver);
        Button botonagregar = (Button) findViewById(R.id.bAgregar);
        Button botonagregarcliente = (Button) findViewById(R.id.bAgregarCliente);
        Button botonlimpiar = (Button) findViewById(R.id.bLimpiar);

        final EditText CodigoArticulo = (EditText) findViewById(R.id.xCodigoArticulo);
        final TextView xDescripcionArticulo = (TextView) findViewById(R.id.xDescripcionArticulo);
        final EditText xCantidadArticulo = (EditText) findViewById(R.id.xCantidadArticulo);
        final MaskedEditText xRutCliente = (MaskedEditText) this.findViewById(R.id.masked_edit_text);
        final EditText xNumeroDTE = (EditText) findViewById(R.id.xNumeroDTE);
        final EditText xNombreCliente = (EditText) findViewById(R.id.xNombreCliente);

        final TextView ElNeto = (TextView) findViewById(R.id.lNeto);
        final TextView ElIva = (TextView) findViewById(R.id.LIva);
        final TextView ElTotal = (TextView) findViewById(R.id.lTotal);

        ////// Declarar variables y inicializacion de arreglos...
        final ListView listView=(ListView)findViewById(R.id.listaarticulos);
        final ArrayList<HashMap<String, String>> list;
        list=new ArrayList<HashMap<String,String>>();
        final ListViewAdapter adapter=new ListViewAdapter(this, list);

        LayoutInflater inflater = getLayoutInflater();
        ViewGroup header = (ViewGroup) inflater.inflate(R.layout.header, listView, false);
        listView.addHeaderView(header, null, false);

        listView.setAdapter(adapter);
        ObtenerTamañoLista(listView);

        final TextView labeliva = (TextView) findViewById(R.id.LIva);
        labeliva.setPaintFlags(labeliva.getPaintFlags() | Paint.UNDERLINE_TEXT_FLAG);

        /// LLena Spinner Tipo Doc
        ArrayAdapter adapter_tipodoc = ArrayAdapter.createFromResource(this,R.array.tiposdoc,R.layout.spinner_item_grande);
        tiposdocs.setAdapter(adapter_tipodoc);

        /// LLena Spinner Forma de Pago
        ArrayAdapter adapterformapago = ArrayAdapter.createFromResource(this,R.array.formasdepago,R.layout.spinner_item_grande);
        formasdepago.setAdapter(adapterformapago);

        final String rutusuarioactual = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //////////// CARGAR CAF DE ACUERDO AL TIPO DE DOCUMENTO

        tiposdocs.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";
                final String eltipodoc = tiposdocs.getSelectedItem().toString();

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);

                            boolean success = jsonResponse.getBoolean("success");
                            String elcorrelativo = jsonResponse.getString("correlativo");

                            if(success){
                                if (elcorrelativo.equals("null")){
                                    xNumeroDTE.setText("");
                                    android.support.v7.app.AlertDialog.Builder builder = new android.support.v7.app.AlertDialog.Builder(venta_detallada.this);
                                    builder.setMessage("Favor, Ingresar CAF.")
                                            .setNegativeButton("Aceptar", null)
                                            .create()
                                            .show();
                                }else{
                                    xNumeroDTE.setText(elcorrelativo);
                                    CAF = elcorrelativo;
                                }
                            }else{
                                xNumeroDTE.setText("");
                                android.support.v7.app.AlertDialog.Builder builder = new android.support.v7.app.AlertDialog.Builder(venta_detallada.this);
                                builder.setMessage("Sin CAF Disponible.")
                                        .setNegativeButton("Aceptar", null)
                                        .create()
                                        .show();
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                respuesta_buscar_CAF buscarcafRequest = new respuesta_buscar_CAF(eltipodoc, laidkey, rutusuarioactual, responselistener);
                RequestQueue queue = Volley.newRequestQueue(venta_detallada.this);
                queue.add(buscarcafRequest);
            }
            @Override
            public void onNothingSelected(AdapterView<?> parentView) {
                // your code here
            }
        });




        ////  OBTENER Y CARGAR LOS DATOS DEL ARTICULO

        xCantidadArticulo.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            public void onFocusChange(View v, boolean hasFocus) {

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";
                final String elcodigodelarticulo = CodigoArticulo.getText().toString();

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if(success){
                                String elcodigoarticulo = jsonResponse.getString("codigoarticulo");
                                String ladescarticulo = jsonResponse.getString("descarticulo");
                                Integer elpreciodelarticuloo = jsonResponse.getInt("precioarticulo");

                                Integer numerocaracteres = ladescarticulo.length();

                                if(numerocaracteres >= 30){
                                    final String descripcion_corta = ladescarticulo.substring(0,30);
                                    Descripcion_Corta = descripcion_corta+"...";
                                }else{
                                    Descripcion_Corta = ladescarticulo;
                                }


                                xDescripcionArticulo.setText(Descripcion_Corta);
                                xCantidadArticulo.setText("1");

                                int pos = xCantidadArticulo.getText().length();
                                xCantidadArticulo.setSelection(pos);
                                Descripcion_Articulo = ladescarticulo;
                            }else{
                                if (elcodigodelarticulo != ""){
                                    xDescripcionArticulo.setText("Artículo No se encuentra Registrado.");
                                    Descripcion_Articulo = "Sin Descripción";
                                    CodigoArticulo.setFocusable(true);
                                }
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                respuesta_buscar_articulo buscararticuloRequest = new respuesta_buscar_articulo(elcodigodelarticulo, laidkey, rutusuarioactual, responselistener);
                RequestQueue queue = Volley.newRequestQueue(venta_detallada.this);
                queue.add(buscararticuloRequest);

            }
        });




        ///////////// CARGAR NOMBRE DEL CLIENTE

        xRutCliente.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {

                    final String elrutdelcliente = xRutCliente.getUnmaskedText();
                    final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                    Response.Listener<String> responselistener = new Response.Listener<String>(){

                        @Override
                        public void onResponse(String response) {
                            try {
                                JSONObject jsonResponse = new JSONObject(response);
                                boolean success = jsonResponse.getBoolean("success");

                                if(success){
                                    String elnombredelcliente = jsonResponse.getString("nombrecliente");
                                    xNombreCliente.setText(elnombredelcliente);
                                }else{
                                    xNombreCliente.setText("");
                                    AlertDialog.Builder builder = new AlertDialog.Builder(venta_detallada.this);
                                    builder.setMessage("Rut No se encuentra Registrado.")
                                            .setNegativeButton("Aceptar", null)
                                            .create()
                                            .show();
                                }
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                        }
                    };
                    respuesta_buscar_cliente buscarclienteRequest = new respuesta_buscar_cliente(laidkey, elrutdelcliente, responselistener);
                    RequestQueue queue = Volley.newRequestQueue(venta_detallada.this);
                    queue.add(buscarclienteRequest);

                    InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                    imm.hideSoftInputFromWindow(listView.getWindowToken(), 0);
                }
            }
        });



        // AGREGAR ARTICULOS AL LISTVIEW Y BD

        botonagregar.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";
                final String elcodigodelarticulo = CodigoArticulo.getText().toString();
                final String lacantidadelarticulo = xCantidadArticulo.getText().toString();

                final String eltipodoc = tiposdocs.getSelectedItem().toString();
                cantidaddelarticulo = Integer.parseInt(lacantidadelarticulo);

                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if(success){
                                String elcodigoarticulo = jsonResponse.getString("codigoarticulo");
                                String ladescarticulo = jsonResponse.getString("descarticulo");
                                Integer elpreciodelarticuloo = jsonResponse.getInt("precioarticulo");
                                Integer iva = jsonResponse.getInt("iva");

                                /// AGREGAR A LA LISTA DE COMPRA
                                HashMap<String,String> tempo=new HashMap<String, String>();
                                // tempo.put(FIRST_COLUMN, elcodigoarticulo);
                                tempo.put(SECOND_COLUMN, ladescarticulo);
                                tempo.put(THIRD_COLUMN, elpreciodelarticuloo + "");
                                tempo.put(FOURTH_COLUMN, lacantidadelarticulo);
                                list.add(tempo);

                                adapter.notifyDataSetChanged();
                                listView.setAdapter(adapter);
                                ObtenerTamañoLista(listView);

                                //// Setea valores iniciales
                                CodigoArticulo.setText("");
                                xDescripcionArticulo.setText("");
                                xCantidadArticulo.setText("");
                                CodigoArticulo.setFocusable(true);

                                DTE_Neto = (elpreciodelarticuloo * cantidaddelarticulo);
                                DTE_NetoT = DTE_NetoT + DTE_Neto;

                                DTE_Iva_Unitario = (((elpreciodelarticuloo) * iva) / 100);
                                DTE_Iva = (((elpreciodelarticuloo * cantidaddelarticulo) * iva) / 100);
                                DTE_IvaT = DTE_IvaT + DTE_Iva;

                                DTE_Total = DTE_Neto + DTE_Iva;
                                DTE_TotalT = DTE_TotalT + DTE_Total;


                                /////////////// AGREGAR ARTICULOS A LA BASE DE DATOS CON ESTADO CONFIRMADO = 0

                                Response.Listener<String> responselistener = new Response.Listener<String>(){

                                    @Override
                                    public void onResponse(String response) {
                                        try {
                                            JSONObject jsonResponse = new JSONObject(response);
                                            boolean success = jsonResponse.getBoolean("success");

                                            if(success){
                                                /// pasa sin problemas
                                            }else{
                                                AlertDialog.Builder builder = new AlertDialog.Builder(venta_detallada.this);
                                                builder.setMessage("Problema al agregar Articulo.")
                                                        .setNegativeButton("Aceptar", null)
                                                        .create()
                                                        .show();
                                            }

                                        } catch (JSONException e) {
                                            e.printStackTrace();
                                        }
                                    }
                                };

                                respuesta_detalle_registro_articulo detallerarticuloRequest = new
                                        respuesta_detalle_registro_articulo(elcodigoarticulo, ladescarticulo,
                                        elpreciodelarticuloo, cantidaddelarticulo, DTE_Iva_Unitario, eltipodoc, CAF, laidkey,
                                        responselistener);
                                RequestQueue queue = Volley.newRequestQueue(venta_detallada.this);
                                queue.add(detallerarticuloRequest);

                                final String DTE_NetoTS = DTE_NetoT + "";
                                final String DTE_IvaTS = DTE_IvaT + "";
                                final String DTE_TotalTS = DTE_TotalT + "";

                                final String montonetonumerico = formatodenumero(DTE_NetoTS);
                                final String montoivanumerico = formatodenumero(DTE_IvaTS);
                                final String montototalnumerico = formatodenumero(DTE_TotalTS);

                                ElNeto.setText("NETO: $ " + montonetonumerico);
                                ElIva.setText("IVA: $ " + montoivanumerico);
                                ElTotal.setText("TOTAL: $ " + montototalnumerico);

                                Toast mensajeconfirmacion = Toast.makeText(getApplicationContext(), "Artículo Agregado Correctamente", Toast.LENGTH_SHORT);
                                mensajeconfirmacion.show();

                                InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                                imm.hideSoftInputFromWindow(listView.getWindowToken(), 0);

                            }else{
                                xDescripcionArticulo.setText("");
                                AlertDialog.Builder builder = new AlertDialog.Builder(venta_detallada.this);
                                builder.setMessage("La Busqueda ha Fallado")
                                        .setNegativeButton("Aceptar", null)
                                        .create()
                                        .show();
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                respuesta_buscar_articulo buscararticuloRequest = new respuesta_buscar_articulo(elcodigodelarticulo, laidkey, rutusuarioactual, responselistener);
                RequestQueue queue = Volley.newRequestQueue(venta_detallada.this);
                queue.add(buscararticuloRequest);
            }

        });


        //Llama al activity de Menu Ventas
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirmenuventas = new Intent(venta_detallada.this,menu_ventas.class);
                startActivity(abrirmenuventas);
            }

        });


        //Llama al activity de Preview
        botonemitirdoc.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                String montoneto = DTE_NetoT + "";
                String montoiva = DTE_IvaT + "";
                String montototal = DTE_TotalT + "";

                final String eltipodoc = tiposdocs.getSelectedItem().toString();
                final String laformapago = formasdepago.getSelectedItem().toString();
                final String elrutdelcliente = xRutCliente.getUnmaskedText();

                Intent abrirpreview = new Intent(venta_detallada.this,venta_detallada_preview.class);
                abrirpreview.putExtra("monto_neto",montoneto);
                abrirpreview.putExtra("monto_iva",montoiva);
                abrirpreview.putExtra("monto_total",montototal);
                abrirpreview.putExtra("tipodoc",eltipodoc);
                abrirpreview.putExtra("formapago",laformapago);
                abrirpreview.putExtra("rutdelcliente",elrutdelcliente);

                startActivity(abrirpreview);


            }

        });

        //Boton de Limpiar
        botonlimpiar.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                CodigoArticulo.setText("");
                xDescripcionArticulo.setText("");
                xCantidadArticulo.setText("");
                listView.setAdapter(null);
                Intent abrirdte= new Intent(venta_detallada.this,venta_detallada.class);
                startActivity(abrirdte);
            }

        });

        //Boton de Agregar Cliente
        botonagregarcliente.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirclientes= new Intent(venta_detallada.this,clientes.class);
                startActivity(abrirclientes);
            }

        });


        // Tooltip Descripcion Articulo
        xDescripcionArticulo.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                AlertDialog.Builder builder = new AlertDialog.Builder(venta_detallada.this);
                builder.setMessage(Descripcion_Articulo)
                        .setNegativeButton("Aceptar", null)
                        .create()
                        .show();
            }

        });

    }

    // Funcion para formatear numeros
    public static String formatodenumero(String elnumero){

        DecimalFormat df;
        DecimalFormat dfnd;
        boolean hasFractionalPart;

        String resultado = "";

        DecimalFormatSymbols simbolos = new DecimalFormatSymbols();
        simbolos.setDecimalSeparator(',');
        simbolos.setGroupingSeparator('.');

        df = new DecimalFormat("#,###.##", simbolos);
        dfnd = new DecimalFormat("#,###", simbolos);
        hasFractionalPart = false;

        int inilen, endlen;
        inilen = elnumero.length();

        String v = elnumero.toString().replace(String.valueOf(df.getDecimalFormatSymbols().getGroupingSeparator()), "");
        Number n = null;
        try {
            n = df.parse(v);
        } catch (ParseException e) {
            e.printStackTrace();
        }

        if (hasFractionalPart) {
            /// setea valor
            elnumero = (df.format(n));
        } else {
            /// setea valor
            elnumero = (dfnd.format(n));
        }


        resultado = elnumero;

        return resultado;
    }

    // Funcion para hacer Crecer una Lista Contenida en un Scroll View
    void ObtenerTamañoLista(ListView wLista) {
        ListAdapter myListAdapter = wLista.getAdapter();
        if (myListAdapter == null) {
            // do nothing return null
            return;
        }
        // Contalibiliza todos los Items de la Lista
        int totalHeight = 0;
        for (int size = 0; size < myListAdapter.getCount(); size++) {
            View listItem = myListAdapter.getView(size, null, wLista);
            listItem.measure(0, 0);
            totalHeight += listItem.getMeasuredHeight();
        }
        //Configura el Listview
        ViewGroup.LayoutParams params = wLista.getLayoutParams();
        params.height = totalHeight
                + (wLista.getDividerHeight() * (myListAdapter.getCount() - 1));
        wLista.setLayoutParams(params);
        // print height of adapter on log
        Log.i("height of listItem:", String.valueOf(totalHeight));
    }


    public static boolean verificaConexion(Context ctx) {
        boolean bConectado = false;
        ConnectivityManager connec = (ConnectivityManager) ctx
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
