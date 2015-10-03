Imports Microsoft.WindowsAzure.Storage
Imports Microsoft.WindowsAzure.Storage.Auth
Imports Microsoft.WindowsAzure.Storage.Queue

Public Class Form1

    'Declaraciones
    Private m_csa_storageAccount As CloudStorageAccount
    Dim sNombreCola As String = Nothing

    Public ReadOnly Property Csa_storageAccount() As CloudStorageAccount
        Get
            If m_csa_storageAccount Is Nothing Then
                Dim strAccount As String = My.Settings.sCuenta
                Dim strKey As String = My.Settings.sKey

                Dim credential As New StorageCredentials(strAccount, strKey)
                m_csa_storageAccount = New CloudStorageAccount(credential, True)
            End If
            Return m_csa_storageAccount
        End Get

    End Property

    Sub CREARCola()

        Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
        Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola
        Queue.CreateIfNotExists() ' Creo la cola si no existe
        MsgBox("Cola creada: " & sNombreCola.ToString)

    End Sub
    Sub PUTCola(ByVal sMensaje As String)

        Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
        Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola

        Dim Message As New CloudQueueMessage(sMensaje) 'Creo el objeto mensaje
        Queue.AddMessage(Message) ' Coloco el mensaje en la cola

    End Sub

    Sub GETCola()

        Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
        Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola

        ' obtener mensaje
        Dim retrievedMessage = Queue.GetMessage 'Obtengo el mensaje desde la cola

        Try
            Queue.GetMessage(TimeSpan.FromSeconds(5)) 'Obtengo el mensaje y lo retengo por 5 segundos
            MsgBox("Mensaje obtenido de la cola: " & retrievedMessage.AsString) 'Visualizo el contenido del mensaje de la cola
        Catch ex As Exception

        End Try

    End Sub

    Sub ELIMINACola()

        Dim cClient As CloudQueueClient = Csa_storageAccount.CreateCloudQueueClient 'Creo el objeto cliente
        Dim Queue = cClient.GetQueueReference(My.Settings.sNombreCola.ToString) 'Obtengo el objeto cola

        ' obtener mensaje
        Dim retrievedMessage = Queue.GetMessage 'Obtengo el mensaje desde la cola

        Try
            Queue.DeleteMessage(retrievedMessage.Id.ToString, retrievedMessage.PopReceipt) 'Elimino el mensaje desde la cola indicando el ID
            MsgBox("Mensaje borrado de la cola :" & retrievedMessage.Id.ToString) 'Visualizo el ID del mensaje eliminado
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCrearCola.Click

        sNombreCola = InputBox("Escriba el nombre para la Cola:", "Crear Cola de Mensajes")

        If sNombreCola.Length > 0 Then
            My.Settings.sNombreCola = sNombreCola.ToString
            My.Settings.Save()
            CREARCola()
        Else
            MsgBox("Debe ingresar un nombre para la cola, no se creo la cola",, "Aviso")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCrearMensajeCola.Click

        PUTCola(InputBox("Escriba el mensaje para la cola:", "Crear Mensaje en cola"))
        MsgBox("Mensaje Creado")

    End Sub

    Private Sub btnLeerMensajeCola_Click(sender As Object, e As EventArgs) Handles btnLeerMensajeCola.Click
        GETCola()
    End Sub

    Private Sub btnEliminarMensaje_Click(sender As Object, e As EventArgs) Handles btnEliminarMensaje.Click
        ELIMINACola()
    End Sub
End Class
