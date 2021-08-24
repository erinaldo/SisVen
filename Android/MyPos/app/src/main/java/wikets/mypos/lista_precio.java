package wikets.mypos;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.lowagie.text.Document;
import com.lowagie.text.DocumentException;
import com.lowagie.text.Element;
import com.lowagie.text.Image;
import com.lowagie.text.Paragraph;
import com.lowagie.text.Phrase;
import com.lowagie.text.pdf.PdfPCell;
import com.lowagie.text.pdf.PdfPTable;
import com.lowagie.text.pdf.PdfWriter;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.HashMap;

import harmony.java.awt.Color;

import static wikets.mypos.constantes.SECOND_COLUMN;
import static wikets.mypos.constantes.THIRD_COLUMN;
import static wikets.mypos.constantes.FOURTH_COLUMN;

/**
 * Created by Miguel on 03-05-2018.
 **/

public class lista_precio extends AppCompatActivity {
    private final int REQUEST_CODE_ASK_PERMISSIONS = 123;

    private String tipomodo;
    private String String_codigo = "";
    private String String_precio = "";
    private String String_descripcion = "";
    private String fecha_actual = "";

    private final static String NOMBRE_DIRECTORIO = "MyPdf";
    private final static String NOMBRE_DOCUMENTO = "listado_precios.pdf";
    private final static String ETIQUETA_ERROR = "ERROR";
    Button bSalir, bListado, bPDF;
    String [][] listado;
    private int contadorlistado = 0;
    Context context;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.lista_precio);


        final Resources res = getResources();

        android.support.v7.app.ActionBar actionbar = getSupportActionBar();
        actionbar.setTitle("Listado de Precios");
        actionbar.setSubtitle("MC-04");

        bSalir = (Button) findViewById(R.id.bVolver);
        bListado = (Button) findViewById(R.id.bListado);
        bPDF = (Button) findViewById(R.id.bImprimir);
        final RadioButton radioneto = (RadioButton) findViewById(R.id.radio_neto);

        final String rutdelusuario = ((variables_gloabales) this.getApplication()).getRutUsuarioActual();

        final ListView listView=(ListView)findViewById(R.id.listaarticulos);
        final ArrayList<HashMap<String, String>> list;
        list=new ArrayList<HashMap<String,String>>();
        final listado_articulos_adapter adapter=new listado_articulos_adapter(this, list);

        LayoutInflater inflater = getLayoutInflater();
        ViewGroup header = (ViewGroup) inflater.inflate(R.layout.header_listado_articulos, listView, false);
        listView.addHeaderView(header, null, false);

        listView.setAdapter(adapter);
        ObtenerTamañoLista(listView);
        VerificarPermisos();

        // LLena la lista de articulos
        bListado.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                list.clear();
                adapter.notifyDataSetChanged();

                final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                if (radioneto.isChecked()){
                    tipomodo = "NETO";
                }else{
                    tipomodo = "TOTAL";
                }


                Response.Listener<String> responselistener = new Response.Listener<String>(){

                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if(success){
                                Integer elcontadorint = jsonResponse.getInt("contador");
                                String elcontadorstring = jsonResponse.getString("contador");

                                for (int i=0; i<elcontadorint; i++)
                                {
                                    String_codigo = "codigoarticulo"+(i+1);
                                    String elcodigo = jsonResponse.getString(String_codigo);

                                    String_precio = "precioarticulo"+(i+1);
                                    String elprecio = jsonResponse.getString(String_precio);

                                    String_descripcion = "descarticulo"+(i+1);
                                    String ladescripcion = jsonResponse.getString(String_descripcion);

                                    final String elprecionumerico = formatodenumero(elprecio);

                                    HashMap<String,String> tempo=new HashMap<String, String>();
                                    // tempo.put(FIRST_COLUMN, elcodigoarticulo);
                                    tempo.put(SECOND_COLUMN, elcodigo);
                                    tempo.put(THIRD_COLUMN, elprecionumerico);
                                    tempo.put(FOURTH_COLUMN, ladescripcion);
                                    list.add(tempo);

                                    adapter.notifyDataSetChanged();
                                    listView.setAdapter(adapter);
                                    ObtenerTamañoLista(listView);
                                }

                            }else{
                                AlertDialog.Builder builder = new AlertDialog.Builder(lista_precio.this);
                                builder.setMessage("No hay artículos Registrados.")
                                        .setNegativeButton("Aceptar", null)
                                        .create()
                                        .show();
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }


                    }
                };

                respuesta_lista_precio listarpreciosRequest = new respuesta_lista_precio(tipomodo, laidkey, rutdelusuario, responselistener);
                RequestQueue queue = Volley.newRequestQueue(lista_precio.this);
                queue.add(listarpreciosRequest);

            }

        });



        //Llama al activity de Menu de Consultas
        bSalir.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){
                Intent abrirconsultas = new Intent(lista_precio.this,consultas.class);
                startActivity(abrirconsultas);
            }

        });


        //Llama al activity PDF
        bPDF.setOnClickListener(new View.OnClickListener()  {

            public void onClick(View view){

                Document documento = new Document();

                try {

                    // Creamos el fichero con el nombre que deseemos.
                    File f = crearFichero(NOMBRE_DOCUMENTO);
                    FileOutputStream ficheroPdf = new FileOutputStream(
                            f.getAbsolutePath());

                    PdfWriter writer = PdfWriter.getInstance(documento, ficheroPdf);

                    // Incluimos el píe de página y una cabecera
                    // HeaderFooter cabecera = new HeaderFooter(new Phrase(
                    //       "Esta es mi cabecera"), false);
                    //HeaderFooter pie = new HeaderFooter(new Phrase(
                    //      "pie de pagina"), false);

                    //documento.setHeader(cabecera);
                    //documento.setFooter(pie);

                    documento.open();

                    // Añadimos un título con la fuente por defecto.
                    Paragraph fecha = new Paragraph(fecha_actual);
                    fecha.setAlignment(Element.ALIGN_RIGHT);
                    documento.add(fecha);


                    // Añadimos un título con una fuente personalizada.
                    //Font font = FontFactory.getFont(FontFactory.HELVETICA, 28,
                    //      Font.BOLD, Color.RED);
                    //documento.add(new Paragraph("Título personalizado", font));


                    // Insertamos una imagen que se encuentra en los recursos de la
                    // aplicación.
                    Bitmap bitmap = BitmapFactory.decodeResource(res, R.drawable.logo4);
                    ByteArrayOutputStream stream = new ByteArrayOutputStream();
                    bitmap.compress(Bitmap.CompressFormat.JPEG, 100, stream);
                    Image imagen = Image.getInstance(stream.toByteArray());
                    imagen.scalePercent(50);
                    documento.add(imagen);

                    Paragraph espacio = new Paragraph("  ");
                    espacio.setAlignment(Element.ALIGN_CENTER);
                    documento.add(espacio);

                    Paragraph titulo = new Paragraph("LISTADO DE PRECIOS");
                    titulo.setAlignment(Element.ALIGN_CENTER);
                    documento.add(titulo);
                    documento.add(espacio);
                    documento.add(espacio);


                    // LineSeparator ls = new LineSeparator();
                    //documento.add(new Chunk(ls));

                    PdfPTable table = new PdfPTable(3);
                    table.setWidths(new int[]{ 1, 4, 1});

                    PdfPCell celda1;
                    celda1 = new PdfPCell(new Phrase("CÓDIGO"));
                    celda1.setBackgroundColor(Color.orange);
                    table.addCell(celda1);

                    PdfPCell celda2;
                    celda2 = new PdfPCell(new Phrase("DESCRIPCIÓN"));
                    celda2.setBackgroundColor(Color.orange);
                    table.addCell(celda2);

                    PdfPCell celda3;
                    celda3 = new PdfPCell(new Phrase("PRECIO"));
                    celda3.setBackgroundColor(Color.orange);
                    table.addCell(celda3);

                    //////////////////////////



                    if (radioneto.isChecked()){
                        tipomodo = "NETO";
                    }else{
                        tipomodo = "TOTAL";
                    }

                    final String laidkey = "sadf4356789dsfgtyt5g5gt5tg5nbmo1092384nfd";

                    Response.Listener<String> responselistener = new Response.Listener<String>(){

                        @Override
                        public void onResponse(String response) {
                            try {
                                JSONObject jsonResponse = new JSONObject(response);
                                boolean success = jsonResponse.getBoolean("success");

                                if(success){
                                    Integer elcontadorint = jsonResponse.getInt("contador");
                                    String elcontadorstring = jsonResponse.getString("contador");
                                    fecha_actual = jsonResponse.getString("fecha_actual");

                                    listado = new String[elcontadorint][3];
                                    contadorlistado = elcontadorint;

                                    for (int i=0; i<elcontadorint; i++)
                                    {
                                        String_codigo = "codigoarticulo"+(i+1);
                                        String elcodigo = jsonResponse.getString(String_codigo);

                                        String_precio = "precioarticulo"+(i+1);
                                        String elprecio = jsonResponse.getString(String_precio);

                                        String_descripcion = "descarticulo"+(i+1);
                                        String ladescripcion = jsonResponse.getString(String_descripcion);

                                        int preciotemporal =  Double.valueOf(elprecio).intValue();
                                        String elpreciotemporal = "" + preciotemporal;

                                        final String elprecionumerico = "$ " + formatodenumero(elpreciotemporal);


                                        listado[i][0] = elcodigo;
                                        listado[i][1] = ladescripcion;
                                        listado[i][2] = elprecionumerico;

                                    }

                                }else{
                                    AlertDialog.Builder builder = new AlertDialog.Builder(lista_precio.this);
                                    builder.setMessage("No hay artículos Registrados.")
                                            .setNegativeButton("Aceptar", null)
                                            .create()
                                            .show();
                                }

                            } catch (JSONException e) {
                                e.printStackTrace();
                            }


                        }
                    };

                    respuesta_lista_precio listarpreciosRequest = new respuesta_lista_precio(tipomodo, laidkey, rutdelusuario, responselistener);
                    RequestQueue queue = Volley.newRequestQueue(lista_precio.this);
                    queue.add(listarpreciosRequest);



                    //////////////////////////
                    for (int i=0; i<contadorlistado; i++)
                    {

                        table.addCell(listado[i][0]);
                        table.addCell(listado[i][1]);
                        table.addCell(listado[i][2]);
                    }

                    if(contadorlistado == 0){
                        bPDF.setText("DESCARGAR");
                    }else{
                        AlertDialog.Builder builder = new AlertDialog.Builder(lista_precio.this);
                        builder.setMessage("PDF Generado Exitosamente.")
                                .setNegativeButton("Aceptar", null)
                                .create()
                                .show();
                    }



                    documento.add(table);






                    // Agregar marca de agua
                   /* font = FontFactory.getFont(FontFactory.HELVETICA, 42, Font.BOLD,
                            Color.GRAY);
                    ColumnText.showTextAligned(writer.getDirectContentUnder(),
                            Element.ALIGN_CENTER, new Paragraph(
                                    "Jorge Antonio Parra Parra", font), 297.5f, 421,
                            writer.getPageNumber() % 2 == 1 ? 45 : -45);*/


                } catch (DocumentException e) {
                    Log.e(ETIQUETA_ERROR, e.getMessage());
                } catch (IOException e) {
                    Log.e(ETIQUETA_ERROR, e.getMessage());
                } finally {
                    // Cerramos el documento.
                    documento.close();

                }
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
            //elnumero = (df.format(n));
            elnumero = (dfnd.format(n));
        } else {
            /// setea valor
            elnumero = (dfnd.format(n));
        }


        resultado = elnumero;

        return resultado;
    }

    public static File crearFichero(String nombreFichero) throws IOException {
        File ruta = getRuta();
        File fichero = null;
        if (ruta != null)
            fichero = new File(ruta, nombreFichero);
        return fichero;
    }

    public static File getRuta() {
        File ruta = null;
        if (Environment.MEDIA_MOUNTED.equals(Environment
                .getExternalStorageState())) {
            ruta = new File(
                    Environment
                            .getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS),
                    NOMBRE_DIRECTORIO);
            if (ruta != null) {
                if (!ruta.mkdirs()) {
                    if (!ruta.exists()) {
                        return null;
                    }
                }
            }
        } else {
        }
        return ruta;
    }

    private void VerificarPermisos() {

        if (Build.VERSION.SDK_INT < Build.VERSION_CODES.M) {
            //Toast.makeText(this, "This version is not Android 6 or later " + Build.VERSION.SDK_INT, Toast.LENGTH_LONG).show();
        } else {

            int hasWriteContactsPermission = checkSelfPermission(Manifest.permission.WRITE_EXTERNAL_STORAGE);

            if (hasWriteContactsPermission != PackageManager.PERMISSION_GRANTED) {
                requestPermissions(new String[] {Manifest.permission.WRITE_EXTERNAL_STORAGE},
                        REQUEST_CODE_ASK_PERMISSIONS);
                bPDF.setEnabled(false);

            }else if (hasWriteContactsPermission == PackageManager.PERMISSION_GRANTED){
                //Toast.makeText(this, "The permissions are already granted ", Toast.LENGTH_LONG).show();
            }

        }

        return;
    }
    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        if(REQUEST_CODE_ASK_PERMISSIONS == requestCode) {
            if (grantResults[0] == PackageManager.PERMISSION_GRANTED)
            {
                Toast.makeText(this, "Permisos Otorgados!", Toast.LENGTH_LONG).show();
            }
            else
            {
                Toast.makeText(this, "Permisos Denegados!", Toast.LENGTH_LONG).show();
            }
        }else{
            super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
