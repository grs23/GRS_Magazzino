Namespace My
    ' Per MyApplication sono disponibili gli eventi seguenti:
    ' Startup: generato all'avvio dell'applicazione, prima della creazione del form di avvio.
    ' Shutdown: generato dopo la chiusura di tutti i form dell'applicazione. Questo evento non viene generato se l'applicazione termina in modo anomalo.
    ' UnhandledException: generato se nell'applicazione si verifica un'eccezione non gestita.
    ' StartupNextInstance: generato all'avvio di un'applicazione a istanza singola se l'applicazione è già attiva. 
    ' NetworkAvailabilityChanged: generato quando la connessione di rete viene connessa o disconnessa.
    Partial Friend Class MyApplication
        Private WithEvents Domain As AppDomain = AppDomain.CurrentDomain

        Private Function Domain_AssemblyResolve(sender As Object, e As ResolveEventArgs) As Reflection.Assembly Handles Domain.AssemblyResolve
            If e.Name.Contains("GRSLib") Then
                Return Reflection.Assembly.Load(Resources.GRSLib)
            ElseIf e.Name.Contains("MySql.Data") Then
                Return Reflection.Assembly.Load(Resources.MySql_Data)
            ElseIf e.Name.Contains("Microsoft.Office.Interop.Excel") Then
                Return Reflection.Assembly.Load(Resources.Microsoft_Office_Interop_Excel)

                Return Nothing
                ' Return Reflection.Assembly.Load(Resources.Guna_UI)
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace
