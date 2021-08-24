package wikets.mypos;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

/**
 * Created by Miguel on 04-05-2018.
 */

public class respuesta_boleta_detallada extends StringRequest {
    private static final String REGISTROBOLETADETALLE_REQUEST_URL = "http://wikets.cl/MyPos/RegistroBoletaConDetalle.php";
    private Map<String, String> params;

    public respuesta_boleta_detallada(Integer montoneto, Integer montoiva, Integer montototal,
                                      String tipodoc, String formapago, String idkey, String usuario,
                                      String rutusuario, String rutcliente, Response.Listener<String> listener){
        super(Method.POST, REGISTROBOLETADETALLE_REQUEST_URL, listener, null );
        params = new HashMap<>();
        params.put("montoneto", montoneto + "");
        params.put("montoiva", montoiva + "");
        params.put("montototal", montototal + "");
        params.put("tipodoc", tipodoc);
        params.put("formapago", formapago);
        params.put("id_key", idkey);
        params.put("usuario", usuario);
        params.put("rutusuario", rutusuario);
        params.put("rutcliente", rutcliente);
    }

    @Override
    public Map<String, String> getParams(){
        return params;
    }
}
