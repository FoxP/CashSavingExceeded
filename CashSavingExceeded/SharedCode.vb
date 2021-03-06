﻿'-----------------------------------------------------------------------------------------------------------------------------------------------
'
'	This program is free software; you can redistribute it and/or
'	modify it under the terms of the GNU General Public License
'	as published by the Free Software Foundation; either version 2
'	of the License, or (at your option) any later version.
'
'	This program is distributed in the hope that it will be useful,
'	but WITHOUT ANY WARRANTY; without even the implied warranty of
'	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'	GNU General Public License for more details.
'
'	You should have received a copy of the GNU General Public License
'	along with this program; if not, write to the Free Software Foundation,
'	Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
'
'	Name :
'				CashSavingExceeded
'	Author :
'				▄▄▄▄▄▄▄  ▄ ▄▄ ▄▄▄▄▄▄▄
'				█ ▄▄▄ █ ██ ▀▄ █ ▄▄▄ █
'				█ ███ █ ▄▀ ▀▄ █ ███ █
'				█▄▄▄▄▄█ █ ▄▀█ █▄▄▄▄▄█
'				▄▄ ▄  ▄▄▀██▀▀ ▄▄▄ ▄▄
'				 ▀█▄█▄▄▄█▀▀ ▄▄▀█ █▄▀█
'				 █ █▀▄▄▄▀██▀▄ █▄▄█ ▀█
'				▄▄▄▄▄▄▄ █▄█▀ ▄ ██ ▄█
'				█ ▄▄▄ █  █▀█▀ ▄▀▀  ▄▀
'				█ ███ █ ▀▄  ▄▀▀▄▄▀█▀█
'				█▄▄▄▄▄█ ███▀▄▀ ▀██ ▄
'
'-----------------------------------------------------------------------------------------------------------------------------------------------

Imports System.Runtime.InteropServices

Module SharedCode

    'Run hidden Windows command line processes with argument(s)
    Sub startHiddenProcess(ByVal sCommand As String, ByVal sArgs As String)
        Dim p As New ProcessStartInfo(sCommand, sArgs)
        p.WindowStyle = ProcessWindowStyle.Hidden
        p.CreateNoWindow = True
        Process.Start(p)
    End Sub

    'Turn off screen(s)
    'SendMessage(Me.Handle, WM_SYSCOMMAND, CType(SC_MONITORPOWER, IntPtr), CType(MonitorShutoff, IntPtr))
    Public Const WM_SYSCOMMAND As Integer = &H112
    Public Const SC_MONITORPOWER As Integer = &HF170
    Public Const MonitorToLowPower As Integer = 1
    Public Const MonitorShutoff As Integer = 2
    <DllImport("user32.dll")> _
    Function SendMessage(ByVal hWnd As IntPtr, ByVal hMsg As Integer, _
                         ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    'Lock computer
    <DllImport("user32.dll")> _
    Sub LockWorkStation()
    End Sub

    'Hibernate computer
    Sub hibernate()
        'Call startHiddenProcess("Shutdown", "-h")
        Application.SetSuspendState(PowerState.Hibernate, True, True)
    End Sub

    'Sleep computer
    Sub sleep()
        Application.SetSuspendState(PowerState.Suspend, True, True)
    End Sub

    'Shutdown computer
    Sub shutdown()
        Call startHiddenProcess("Shutdown", "-s -f")
    End Sub

    'Reboot computer
    Sub reboot()
        Call startHiddenProcess("Shutdown", "-r -f")
    End Sub

    'Log off user
    Sub logOff()
        Call startHiddenProcess("Shutdown", "-l -f")
    End Sub

    'Abort shutdown / reboot
    Sub cancelShutdown()
        Call startHiddenProcess("Shutdown", "-a")
    End Sub

    'Create Windows shortcut
    'Example : Call createShortCut(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.Startup), "SHORTCUT", "-startminimized")
    Sub createShortCut(ByVal sTargetPath As String, ByVal sShortcutPath As String, ByVal sShortcutName As String, Optional ByVal sArguments As String = "")
        Dim oShell As Object
        Dim oLink As Object
        Try
            oShell = CreateObject("WScript.Shell")
            oLink = oShell.CreateShortcut(sShortcutPath & System.IO.Path.DirectorySeparatorChar & sShortcutName & ".lnk")
            oLink.Arguments = sArguments
            oLink.TargetPath = sTargetPath
            oLink.WindowStyle = 1
            oLink.Save()
        Catch ex As Exception
        End Try
    End Sub

    'Get Windows shortcut target
    Function getShortCutTarget(ByVal sShortcutPath As String) As String
        Dim shell = CreateObject("WScript.Shell")
        getShortCutTarget = shell.CreateShortcut(sShortcutPath).TargetPath
    End Function

    'Get Windows shortcut arguments
    Function getShortCutArguments(ByVal sShortcutPath As String) As String
        Dim shell = CreateObject("WScript.Shell")
        getShortCutArguments = shell.CreateShortcut(sShortcutPath).Arguments
    End Function

    'Add application to Windows startup folder
    Sub addAppToStartupFolder()
        'If shortcut does not exist, create it in Windows startup folder
        If Not System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & System.IO.Path.DirectorySeparatorChar & My.Application.Info.AssemblyName & ".lnk") Then
            Call createShortCut(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.Startup), My.Application.Info.AssemblyName, "--startminimized")
        Else
            'If shortcut exists, check that its target is correct. If not, let's overwrite it
            If (UCase(getShortCutTarget(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & System.IO.Path.DirectorySeparatorChar & My.Application.Info.AssemblyName & ".lnk")) <> UCase(Application.ExecutablePath)) _
            Or (UCase(getShortCutArguments(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & System.IO.Path.DirectorySeparatorChar & My.Application.Info.AssemblyName & ".lnk")) <> "--STARTMINIMIZED") Then
                Call createShortCut(Application.ExecutablePath, Environment.GetFolderPath(Environment.SpecialFolder.Startup), My.Application.Info.AssemblyName, "--startminimized")
            End If
        End If
    End Sub

    'Delete application from Windows startup folder
    Sub deleteAppFromStartupFolder()
        If System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & System.IO.Path.DirectorySeparatorChar & My.Application.Info.AssemblyName & ".lnk") Then
            System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) & System.IO.Path.DirectorySeparatorChar & My.Application.Info.AssemblyName & ".lnk")
        End If
    End Sub

End Module
