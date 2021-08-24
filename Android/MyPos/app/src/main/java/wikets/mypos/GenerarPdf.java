package wikets.mypos;

/**
 * Created by Miguel on 03/05/2018.
 */

import harmony.java.awt.Color;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

import android.Manifest;
import android.app.Activity;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Toast;

import com.lowagie.text.Chunk;
import com.lowagie.text.Document;
import com.lowagie.text.DocumentException;
import com.lowagie.text.Element;
import com.lowagie.text.Font;
import com.lowagie.text.FontFactory;
import com.lowagie.text.HeaderFooter;
import com.lowagie.text.Image;
import com.lowagie.text.Paragraph;
import com.lowagie.text.Phrase;
import com.lowagie.text.pdf.ColumnText;
import com.lowagie.text.pdf.PdfPTable;
import com.lowagie.text.pdf.PdfWriter;
import com.lowagie.text.pdf.draw.LineSeparator;

public class GenerarPdf extends Activity implements OnClickListener {
    private final int REQUEST_CODE_ASK_PERMISSIONS = 123;

    private final static String NOMBRE_DIRECTORIO = "MiPdf";
    private final static String NOMBRE_DOCUMENTO = "listado_precios.pdf";
    private final static String ETIQUETA_ERROR = "ERROR";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        findViewById(R.id.btnGenerar).setOnClickListener(this);
        VerificarPermisos();
    }

    @Override
    public void onClick(View v) {

        Document documento = new Document();

        try {

            // Creamos el fichero con el nombre que deseemos.
            File f = crearFichero(NOMBRE_DOCUMENTO);
            FileOutputStream ficheroPdf = new FileOutputStream(
                    f.getAbsolutePath());

            PdfWriter writer = PdfWriter.getInstance(documento, ficheroPdf);

            // Incluimos el píe de página y una cabecera
            HeaderFooter cabecera = new HeaderFooter(new Phrase(
                    "Esta es mi cabecera"), false);
            HeaderFooter pie = new HeaderFooter(new Phrase(
                    "Este es mi pie de página"), false);

            documento.setHeader(cabecera);
            documento.setFooter(pie);

            documento.open();

            // Añadimos un título con la fuente por defecto.
            documento.add(new Paragraph("Título 1"));

            // Añadimos un título con una fuente personalizada.
            Font font = FontFactory.getFont(FontFactory.HELVETICA, 28,
                    Font.BOLD, Color.RED);
            documento.add(new Paragraph("Título personalizado", font));

            // Insertamos una imagen que se encuentra en los recursos de la
            // aplicación.
            Bitmap bitmap = BitmapFactory.decodeResource(this.getResources(),R.drawable.icon);
            ByteArrayOutputStream stream = new ByteArrayOutputStream();
            bitmap.compress(Bitmap.CompressFormat.JPEG, 100, stream);
            Image imagen = Image.getInstance(stream.toByteArray());
            documento.add(imagen);




            Phrase frase = new Phrase("Ejemplo de iText - El lado oscuro de java ");
            documento.add(frase);


            LineSeparator ls = new LineSeparator();
            documento.add(new Chunk(ls));



            // Insertamos una tabla.
            PdfPTable tabla = new PdfPTable(5);
            for (int i = 0; i < 15; i++) {
                tabla.addCell("Celda " + i);
            }
            documento.add(tabla);

            // Agregar marca de agua
            font = FontFactory.getFont(FontFactory.HELVETICA, 42, Font.BOLD,
                    Color.GRAY);
            ColumnText.showTextAligned(writer.getDirectContentUnder(),
                    Element.ALIGN_CENTER, new Paragraph(
                            "Jorge Antonio Parra Parra", font), 297.5f, 421,
                    writer.getPageNumber() % 2 == 1 ? 45 : -45);

        } catch (DocumentException e) {
            Log.e(ETIQUETA_ERROR, e.getMessage());
        } catch (IOException e) {
            Log.e(ETIQUETA_ERROR, e.getMessage());
        } finally {
            // Cerramos el documento.
            documento.close();
        }
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
                //Toast.makeText(this, "Requesting permissions", Toast.LENGTH_LONG).show();

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