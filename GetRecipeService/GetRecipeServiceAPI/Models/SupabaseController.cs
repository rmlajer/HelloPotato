public class SupabaseController
{


    public async Task<Supabase.Client> InitializeSupabase()
    {



        var url = Environment.GetEnvironmentVariable("SUPABASE_URL");

        var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");


        var options = new Supabase.SupabaseOptions
        {
            AutoConnectRealtime = false
        };

        var supabase = new Supabase.Client(url!, key, options);
        await supabase.InitializeAsync();
        return supabase;
    }
}