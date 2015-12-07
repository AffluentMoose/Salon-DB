Option Explicit On
Imports System.IO

Module modMain

    Public Structure Customer
        Dim ID As Integer
        <VBFixedString(20)> Dim Forename As String
        <VBFixedString(20)> Dim Surname As String
        <VBFixedString(14)> Dim Telephone As String
        <VBFixedString(25)> Dim Address1 As String
        <VBFixedString(25)> Dim Address2 As String
        <VBFixedString(40)> Dim Email As String
        <VBFixedString(1)> Dim Deleted As Short
    End Structure

    Public CustomerRecord As Customer
    Public CustomerFilePath As String = CurDir() & "\CustomerFile.dat"
    Public CustArchiveFilePath As String = CurDir() & "\CustomerArchive.dat"
    Public CurrentCustRNum As Integer 'current customer record number, for opening edit form
    Public CustMaxID As Integer 'highest ID number for customers

    Public Structure Service
        <VBFixedString(20)> Dim Name As String
        <VBFixedString(70)> Dim Description As String
        Dim Price As Decimal
    End Structure

    Public ServiceRecord As Service
    Public ServiceFilePath As String = CurDir() & "\ServiceFile.dat"
    Public SerArchiveFilePath As String = CurDir() & "\ServiceArchive.dat"
    Public CurrentSerRNum As Integer 'current service record number, for opening edit form
    Public ServiceMaxID As Integer 'highest ID number for customers

    Public Structure Appointment
        <VBFixedString(100)> Dim Comment As String
        Dim ID As Integer
        Dim CustomerID As Integer
        <VBFixedString(41)> Dim CustomerName As String
        Dim AppDate As Date
        Dim AppTime As Date
    End Structure

    Public AppointmentRecord As Appointment
    Public AppointmentFilePath As String = CurDir() & "\AppointmentFile.dat"
    Public AppArchiveFilePath As String = CurDir() & "\AppArchive.dat"
    Public CurrentAppRNum As Integer 'current service record number, for opening edit form
    Public AppMaxID As Integer 'highest ID number for customers

    Public Structure AppService
        <VBFixedString(6)> Dim AppID As Integer
        <VBFixedString(20)> Dim ServiceName As String
        <VBFixedString(1)> Dim RecordNumber As Integer 'Number 1-4 representing the combo box from which this record has been saved - used for overwriting records
    End Structure

    Public Structure Settings
        <VBFixedString(50)> Dim Password As String
        <VBFixedString(1)> Dim Scheme As Char
        <VBFixedString(1)> Dim FirstAccess As Char
    End Structure

    Public SettingsRecord As Settings

    Public MaxAppServiceRecordNumber As Integer
    Public AppSerRecord As AppService
    Public AppServFilePath As String = CurDir() & "\AppServiceFile.dat"

    Public IDFileName As String = CurDir() & "\IDs.txt" 'file for IDSs
    Public TempFilePath As String
    Public Editing As Boolean ' used for customer edit form
    Public ItemProgress As Integer 'for printing

    Public SetPassword As String
    Public Scheme As Char
    'Public SchemeFile As String = CurDir() & "\Scheme.txt" 'scheme file
    Public SettingsFilePath As String = CurDir() & "\Settings.dat" 'scheme file
    Public PassCallingForm As Form

End Module

