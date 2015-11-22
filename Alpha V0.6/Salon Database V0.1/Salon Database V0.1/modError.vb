Option Explicit On

Module modError 'mod to do with displaying errors

    Public AlertType As String 'to change layout of box based on alert type
    Public ErrorList As New List(Of String) 'list of errors to pass to message box
    Public ErrorMessages(3) As String 'array of messages to display
    Public CallingForm As Form 'form calling the error
    Public ConfirmAction As Boolean = False 'used for passing back user response from error 
    Public ReturnAction As String = "" 'choice of action the user made 

End Module
