package wikets.mypos;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.TextView;

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
import java.util.Date;
import java.util.HashMap;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class consulta_venta extends AppCompatActivity {

    private String Validacion;
    private String lafechainicio;
    private String lafechafinal;
    private String mododetalle;
    private String RUT_CLIENTE;
    private String NUMDOC;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.consulta_venta);

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Consulta Venta");
        actionbar.setSubtitle("MC-02");

        final MaskedEditText xRutCliente = (MaskedEditText) this.findViewById(R.id.masked_edit_text);
        final EditText xNombreCliente = (EditText) findViewById(R.id.xNombreCliente);
        final EditText xNumDoc = (EditText) findViewById(R.id.xNumDoc);
        final Spinner tiposdocs = (Spinner) findViewById(R.id.spinnertipo);
        final Spinner formasdepago = (Spinner) findViewById(R.id.spinnerpago);
        final Button botonvolver = (Button) findViewById(R.id.bVolver);
        final Button botonconsultar = (Button) findViewById(R.id.bConsultar);

        final DatePicker dpinicio = (DatePicker) findViewById(R.id.xFecha_Inicio);
        final DatePicker dpfinal = (DatePicker) findViewById(R.id.xFecha_Final);
        dpinicio.setMaxDate(new Date().getTime());
        dpfinal.setMaxDate(new Date().getTime());

        /// LLena Spinner Tipo Doc
        ArrayAdapter adapter_tipodoc = ArrayAdapter.createFromResource(this,R.array.tiposdoc,R.layout.spinner_item_grande);
        tiposdocs.setAdapter(adapter_tipodoc);

        /// LLena Spinner Forma de Pago
        ArrayAdapter adapterformapago = ArrayAdapter.createFromResource(this,R.array.formasdepago,R.layout.spinner_item_grande);
        formasdepago.setAdapter(adapterformapago);


        final String usuario = ((variables_gloabales) this.getApplication()).getUsuarioActual();

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
                                    android.support.v7.app.AlertDialog.Builder builder = new android.support.v7.app.AlertDialog.Builder(consulta_venta.this);
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
                    RequestQueue queue = Volley.newRequestQueue(consulta_venta.this);
                    queue.add(buscarclienteRequest);

                    InputMethodManager imm = (InputMethodManager)getSystemService(Context.INPUT_METHOD_SERVICE);
                    imm.hideSoftInputFromWindow(xNumDoc.getWindowToken(), 0);

                }
            }
        });


        //Llama al activity de Menu Consultas
        botonvolver.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirconsultas = new Intent(consulta_venta.this,consultas.class);
                startActivity(abrirconsultas);
            }

        });



        //Llama al activity para consulta de venta
        botonconsultar.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){



                Validacion = "NO";

                final String elrutdelcliente = xRutCliente.getUnmaskedText();

                final String elnumdoc = xNumDoc.getText().toString();
                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                if (elrutdelcliente.equals("")) {
                    RUT_CLIENTE = "";
                }else{
                    RUT_CLIENTE = elrutdelcliente;
                }

                if (elnumdoc.equals("")) {
                    NUMDOC = "";
                }else{
                    NUMDOC = elnumdoc;
                }


                /// ENVIAR PARAMETROS

                ////////// FORMATO A LA FECHA DEL DATAPICKER
                int   day  = dpinicio.getDayOfMonth();
                int   month= dpinicio.getMonth() + 1;
                int   year = dpinicio.getYear();

                String xday = Integer.toString(day);
                String xmonth = Integer.toString(month);
                String xyear = Integer.toString(year);

                int largoxday = xday.length();
                int largoxmonth = xmonth.length();

                if (largoxmonth == 1){
                    if (largoxday == 1){
                        lafechainicio = "" + year + "-0" + month + "-0" + day;
                    }else{
                        lafechainicio = "" + year + "-0" + month + "-" + day;
                    }
                }else{
                    if (largoxday == 1){
                        lafechainicio = "" + year + "-" + month + "-0" + day;
                    }else{
                        lafechainicio = "" + year + "-" + month + "-" + day;
                    }
                }

                ////////// FORMATO A LA FECHA DEL DATAPICKER INICIO Y FINAL
                day  = dpfinal.getDayOfMonth() + 1;
                month= dpfinal.getMonth() + 1;
                year = dpfinal.getYear();

                xday = Integer.toString(day);
                xmonth = Integer.toString(month);
                xyear = Integer.toString(year);

                largoxday = xday.length();
                largoxmonth = xmonth.length();

                if (largoxmonth == 1){
                    if (largoxday == 1){
                        lafechafinal = "" + year + "-0" + month + "-0" + day;
                    }else{
                        lafechafinal = "" + year + "-0" + month + "-" + day;
                    }
                }else{
                    if (largoxday == 1){
                        lafechafinal = "" + year + "-" + month + "-0" + day;
                    }else{
                        lafechafinal = "" + year + "-" + month + "-" + day;
                    }
                }

                final String eltipodoc = tiposdocs.getSelectedItem().toString();
                final String laformapago = formasdepago.getSelectedItem().toString();
                final RadioButton radiosi = (RadioButton) findViewById(R.id.radio_si);

                if (radiosi.isChecked()){
                    mododetalle = "SI";
                    Intent abrirconsultaventadetalle = new Intent(consulta_venta.this,consulta_venta_detallada.class);
                    abrirconsultaventadetalle.putExtra("fecha_inicio",lafechainicio);
                    abrirconsultaventadetalle.putExtra("fecha_final",lafechafinal);
                    abrirconsultaventadetalle.putExtra("rutcliente",RUT_CLIENTE);
                    abrirconsultaventadetalle.putExtra("tipodoc",eltipodoc);
                    abrirconsultaventadetalle.putExtra("formapago",laformapago);
                    abrirconsultaventadetalle.putExtra("numdoc",NUMDOC);
                    abrirconsultaventadetalle.putExtra("mododetalle",mododetalle);
                    abrirconsultaventadetalle.putExtra("idkey",laidkey);
                    abrirconsultaventadetalle.putExtra("usuario",usuario);
                    startActivity(abrirconsultaventadetalle);
                }else{
                    mododetalle = "NO";
                    Intent abrirconsultaventa = new Intent(consulta_venta.this,consulta_de_ventas.class);
                    abrirconsultaventa.putExtra("fecha_inicio",lafechainicio);
                    abrirconsultaventa.putExtra("fecha_final",lafechafinal);
                    abrirconsultaventa.putExtra("rutcliente",RUT_CLIENTE);
                    abrirconsultaventa.putExtra("tipodoc",eltipodoc);
                    abrirconsultaventa.putExtra("formapago",laformapago);
                    abrirconsultaventa.putExtra("numdoc",NUMDOC);
                    abrirconsultaventa.putExtra("mododetalle",mododetalle);
                    abrirconsultaventa.putExtra("idkey",laidkey);
                    abrirconsultaventa.putExtra("usuario",usuario);
                    startActivity(abrirconsultaventa);
                }




            }

        });



    }
}
