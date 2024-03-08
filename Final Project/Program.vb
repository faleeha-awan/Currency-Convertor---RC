Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.Design
Imports System.IO

Module Program
    Sub file_creating()
        Dim file_writer As StreamWriter
        file_writer = File.CreateText("D:/RC/Currency.txt")
        file_writer.Close()
    End Sub
    Sub Currencies()
        Dim File_Reader As StreamReader
        Dim file_data As String
        File_Reader = File.OpenText("D:/RC/Currency.txt")
        For i = 1 To 42
            file_data = File_Reader.ReadLine
            Console.WriteLine(file_data)
        Next i
        File_Reader.Close()
    End Sub


    Sub conversion()
        Dim File_Reader As StreamReader
        Dim File_data, Exchange_rate, amount_to_convert, result, symbol As String
        Dim Currency_to_convert, j As Integer
        Dim Check As Boolean
        Check = False
        Console.WriteLine("Enter the Currency index that you want to convert to US Dollars")
        Currency_to_convert = Console.ReadLine
        Console.WriteLine("Enter the amount that u want to convert")
        amount_to_convert = Console.ReadLine

        File_Reader = File.OpenText("D:/RC/Currency_Convertor.txt")
        j = 1
        While File_Reader.Peek <> -1 And Check = False
            File_data = File_Reader.ReadLine
            If Currency_to_convert = j Then
                Exchange_rate = (Left(File_data, 8))
                result = (1 / Exchange_rate) * amount_to_convert
                symbol = (Right(File_data, 5))
                Console.Write(amount_to_convert, symbol)
                Console.Write(" in US Dollars is ")
                Console.Write(result)
                Console.Write("$")
                Check = True
            End If
            j = j + 1
        End While
        File_Reader.Close()
    End Sub





    Sub Main(args As String())
        'Call file_creating()
        Call Currencies()
        Call conversion()
    End Sub

End Module
