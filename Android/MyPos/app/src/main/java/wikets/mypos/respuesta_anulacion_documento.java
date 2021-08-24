package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_anulacion_documento extends StringRequest {
    private static final String ANULACION_REQUEST_URL = "http://wikets.cl/MyPos/AnularDocumento.php";
    private Map<String, String> params;

    public respuesta_anulacion_documento(String tipodoc, Integer numdoc, String idkey, String usuario, String rutusuario, Response.Listener<String> listener){
        super(Request.Method.POST, ANULACION_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("tipodoc", tipodoc);
        params.put("numdoc", numdoc + "");
        params.put("id_key", idkey);
        params.put("usuario", usuario);
        params.put("rutusuario", rutusuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
