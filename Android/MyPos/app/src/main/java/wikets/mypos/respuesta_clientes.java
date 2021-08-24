package wikets.mypos;

import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 * */

public class respuesta_clientes extends StringRequest {
    private static final String REGISTRO_CLIENTE_REQUEST_URL = "http://wikets.cl/MyPos/RegistroClientes.php";
    private Map<String, String> params;

    public respuesta_clientes(String elrutdelcliente, String elnombredelcliente,
                              String elgirodelcliente, String ladirecciondelcliente,
                              String laciudaddelcliente, String lacomunadelcliente,
                              String elemaildedelcliente, String idkey, String rutusuario,
                              String usuario, Response.Listener<String> listener){
        super(Request.Method.POST, REGISTRO_CLIENTE_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("rutcliente", elrutdelcliente);
        params.put("nombrecliente", elnombredelcliente);
        params.put("girocliente", elgirodelcliente);
        params.put("direccioncliente", ladirecciondelcliente);
        params.put("ciudadcliente", laciudaddelcliente);
        params.put("comunacliente", lacomunadelcliente);
        params.put("emailcliente", elemaildedelcliente);
        params.put("id_key", idkey);
        params.put("rutusuario", rutusuario);
        params.put("usuario", usuario);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }

}
