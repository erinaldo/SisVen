package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_buscar_CAF extends StringRequest {
    private static final String BUSCA_CAF_REQUEST_URL = "http://wikets.cl/MyPos/BuscarCAF.php";
    private Map<String, String> params;

    public respuesta_buscar_CAF(String tipodoc, String idkey, String rutusuario, Response.Listener<String> listener){
        super(Request.Method.POST, BUSCA_CAF_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("tipodoc", tipodoc);
        params.put("id_key", idkey);
        params.put("rutusuario", rutusuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
