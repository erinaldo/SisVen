package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 **/

public class respuesta_buscar_cliente extends StringRequest {
    private static final String BUSCA_CLIENTE_REQUEST_URL = "http://wikets.cl/MyPos/BuscarCliente.php";
    private Map<String, String> params;

    public respuesta_buscar_cliente(String idkey, String rutcliente, Response.Listener<String> listener){
        super(Request.Method.POST, BUSCA_CLIENTE_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("id_key", idkey);
        params.put("rutcliente", rutcliente);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
