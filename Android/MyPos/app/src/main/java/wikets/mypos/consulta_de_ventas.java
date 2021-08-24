package wikets.mypos;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;

import static wikets.mypos.constantes.FIRST_COLUMN;
import static wikets.mypos.constantes.FOURTH_COLUMN;
import static wikets.mypos.constantes.SECOND_COLUMN;
import static wikets.mypos.constantes.THIRD_COLUMN;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class consulta_de_ventas extends AppCompatActivity {

    String fechainicio;
    String fechafinal;
    String rutcliente;
    String tipodoc;
    String formapago;
    String numdoc;
    String mododetalle;
    String idkey;
    String usuario;

    private String String_fecha = "";
    private String String_cliente = "";
    private String String_numdoc = "";
    private String String_monto = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.consulta_de_ventas);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Consulta Venta (Sin Detalle)");
        actionbar.setSubtitle("M-022");

        final TextView el_tipodoc = (TextView) findViewById(R.id.tipodocumento);
        final TextView el_formadepago = (TextView) findViewById(R.id.formadepago);

        final Button botonvolver = (Button) findViewById(R.id.bVolver);

        final ListView listView=(ListView)findViewById(R.id.consultaventa);
        final ArrayList<HashMap<String, String>> list;
        list=new ArrayList<HashMap<String,String>>();
        final listado_ventas_adapter adapter = new listado_ventas_adapter(this, list);

        LayoutInflater inflater = getLayoutInflater();
        ViewGroup header = (ViewGroup) inflater.inflate(R.layout.header_lista_consulta_venta_sin, listView, false);
        listView.addHeaderView(header, null, false);

        listView.setAdapter(adapter);
        ObtenerTamañoLista(listView);

        /// Cargar variables intent
        Intent obtenerextra = getIntent();
        Bundle extras = obtenerextra.getExtras();

        if (extras != null) {
            fechainicio = (String) extras.get("fecha_inicio");
            fechafinal = (String) extras.get("fecha_final");
            rutcliente = (String) extras.get("rutcliente");
            tipodoc = (String) extras.get("tipodoc");
            formapago = (String) extras.get("formapago");
            numdoc = (String) extras.get("numdoc");
            mododetalle = (String) extras.get("mododetalle");
            idkey = (String) extras.get("idkey");
            usuario = (String) extras.get("usuario");
        }


        Response.Listener<String> responselistener = new Response.Listener<String>(){

            @Override
            public void onResponse(String response) {
                try {
                    JSONObject jsonResponse = new JSONObject(response);
                    boolean success = jsonResponse.getBoolean("success");

                    if(success){

                        Integer elcontadorint = jsonResponse.getInt("contador");

                        for (int i=0; i<elcontadorint; i++) {

                            String_fecha = "fecha" + (i + 1);
                            String_cliente = "cliente" + (i + 1);
                            String_numdoc = "numdoc" + (i + 1);
                            String_monto = "monto" + (i + 1);

                            String lafecha = jsonResponse.getString(String_fecha);
                            String elcliente = jsonResponse.getString(String_cliente);
                            String elnumdoc = jsonResponse.getString(String_numdoc);
                            String elmonto = jsonResponse.getString(String_monto);

                            final String rut_1 = elcliente.substring(0,2);
                            final String rut_2 = elcliente.substring(2,5);
                            final String rut_3 = elcliente.substring(5,8);
                            final String rut_4 = elcliente.substring(8,9);

                            final String rut_con_formato = rut_1 + "." + rut_2 + "." + rut_3 + "-" + rut_4;

                            String elmontonuimerico = formatodenumero(elmonto);
                            elmontonuimerico = "$ " + elmontonuimerico;

                            HashMap<String,String> tempo=new HashMap<String, String>();
                            tempo.put(FIRST_COLUMN, lafecha);
                            tempo.put(SECOND_COLUMN, rut_con_formato);
                            tempo.put(THIRD_COLUMN, elnumdoc);
                            tempo.put(FOURTH_COLUMN, elmontonuimerico);
                            list.add(tempo);

                            adapter.notifyDataSetChanged();
                            listView.setAdapter(adapter);
                            ObtenerTamañoLista(listView);
                        }

                        el_tipodoc.setText(tipodoc);
                        el_formadepago.setText(formapago);


                    }else{
                        AlertDialog.Builder builder = new AlertDialog.Builder(consulta_de_ventas.this);
                        builder.setMessage("Consulta sin Resultados")
                                .setNegativeButton("Aceptar", null)
                                .create()
                                .show();
                    }

                } catch (JSONException e) {
                    e.printStackTrace();
                }


            }
        };

        respuesta_consulta_venta consultadeventaRequest = new respuesta_consulta_venta(fechainicio, fechafinal, rutcliente, tipodoc, formapago, numdoc, mododetalle, idkey, usuario, responselistener);
        RequestQueue queue = Volley.newRequestQueue(consulta_de_ventas.this);
        queue.add(consultadeventaRequest);




        //Llama al activity de Menu Consultas
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirconsultaventa = new Intent(consulta_de_ventas.this,consulta_venta.class);
                startActivity(abrirconsultaventa);
            }

        });

    }

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
}
