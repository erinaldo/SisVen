package wikets.mypos;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_detalle_registro_articulo extends StringRequest {
    private static final String REGISTRO_DETELLE_ARTICULO_REQUEST_URL = "http://wikets.cl/MyPos/RegistroDetalleArticulos.php";
    private Map<String, String> params;

    public respuesta_detalle_registro_articulo(String elcodigoarticulo, String ladescarticulo,
                                               Integer elpreciodelarticuloo, Integer cantidaddelarticulo,
                                               Integer DTE_Iva, String eltipodoc, String CAF, String laidkey,
                                               Response.Listener<String> listener){
        super(Method.POST, REGISTRO_DETELLE_ARTICULO_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("elcodigoarticulo", elcodigoarticulo);
        params.put("ladescarticulo", ladescarticulo);
        params.put("elpreciodelarticuloo", elpreciodelarticuloo + "");
        params.put("cantidaddelarticulo", cantidaddelarticulo + "");
        params.put("DTE_Iva", DTE_Iva + "");
        params.put("eltipodoc", eltipodoc);
        params.put("CAF", CAF + "");
        params.put("laidkey", laidkey);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
