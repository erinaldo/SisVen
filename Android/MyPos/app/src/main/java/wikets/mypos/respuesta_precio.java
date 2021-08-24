package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_precio extends StringRequest {
    private static final String REGISTRO_PRECIO_REQUEST_URL = "http://wikets.cl/MyPos/RegistroPrecios.php";
    private Map<String, String> params;

    public respuesta_precio(String codigoarticulo, String nombrearticulo, String barra1, String barra2, String barra3, Integer precio, String idkey, String rutusuario, String usuario, Response.Listener<String> listener){
        super(Request.Method.POST, REGISTRO_PRECIO_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("codigo_articulo", codigoarticulo);
        params.put("nombre_articulo", nombrearticulo);
        params.put("barra_1", barra1);
        params.put("barra_2", barra2);
        params.put("barra_3", barra3);
        params.put("precio", precio + "");
        params.put("id_key", idkey);
        params.put("rutusuario", rutusuario);
        params.put("usuario", usuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
