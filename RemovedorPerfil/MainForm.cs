/*
 * Created by SharpDevelop.
 * User: V7BA
 * Date: 10/06/2015
 * Time: 09:30
 * 
 *
 * links: https://msdn.microsoft.com/pt-br/library/cc148994.aspx
 * http://stackoverflow.com/questions/329355/cannot-delete-directory-with-directory-deletepath-true (excluir perfil)
 * http://stackoverflow.com/questions/2180057/access-to-the-system-path-is-denied-when-using-system-io-directory-delete (excluir perfil setando atributos)
 * 
 * 
 * 
 *  To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;

namespace RemovedorPerfil
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		List<PerfilMicro> listaPerfis = new List<PerfilMicro>();
		List<String> listaExcecoes = new List<String>();
		const string PROFILE_LIST = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList";
		
		
		public MainForm()
		{
			Debug.WriteLine("Executou MainForm");
			InitializeComponent();
			inicializaConfiguracoes();
			carregaPerfisDoRegistro();
			carregaPerfisDaPasta();
			
			
		}
		
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
			Debug.WriteLine("Executou MainFormLoad");
			//this.listaPerfis.Sort();
			((ListBox)this.checkedListBoxPerfisMicro).DataSource = listaPerfis;
			((ListBox)this.checkedListBoxPerfisMicro).DisplayMember = "NomePerfil";
			((ListBox)this.checkedListBoxPerfisMicro).ValueMember = "IsChecked";
			
		}
		
		public void carregaPerfisDoRegistro(){
			escreveLog("Carregando Perfis do registro");
			RegistryKey chave =  Registry.LocalMachine.OpenSubKey(PROFILE_LIST,false);
			
			
			String[] chaves = chave.GetSubKeyNames();
			
			foreach(String item in chaves){
				RegistryKey subchave = Registry.LocalMachine.OpenSubKey(PROFILE_LIST + "\\" + item);
				
				string valor = (string)subchave.GetValue("ProfileImagePath");
				if(valor.Contains("C:\\Users")){
					string[] valorDividido = valor.Split('\\');
					
					if(!listaExcecoes.Contains(valorDividido[2])){
						PerfilMicro perfilEncontrado = listaPerfis.Find(p => p.NomePerfil == valorDividido[2]);
						if(perfilEncontrado != null){
							perfilEncontrado.Registry = item;
						}else{
							PerfilMicro novoPerfil = new PerfilMicro(valorDividido[2]);
							novoPerfil.Registry = item;
							listaPerfis.Add(novoPerfil);
						}
					}
				}
			}
		}
		
		public void carregaPerfisDaPasta(){
			escreveLog("Carregando perfis da pasta");
			string[] pastas = Directory.GetDirectories("C:\\Users\\");
			
			foreach(string valor in pastas){
				string[] valorDividido = valor.Split('\\');
				
				if(!listaExcecoes.Contains(valorDividido[2])){
					PerfilMicro perfilEncontrado = listaPerfis.Find(p => p.NomePerfil == valorDividido[2]);
					if(perfilEncontrado != null){
						perfilEncontrado.FolderPath = valor;
					}else{
						PerfilMicro novoPerfil = new PerfilMicro(valorDividido[2]);
						novoPerfil.FolderPath = valor;
						listaPerfis.Add(novoPerfil);
					}
				}
			}
		}

		
		
		void inicializaConfiguracoes()
		{
			listaExcecoes.Add("Administrador");
			listaExcecoes.Add("All Users");
			listaExcecoes.Add("Clienti");
			listaExcecoes.Add("Default");
			listaExcecoes.Add("Default User");
			listaExcecoes.Add("Public");
			listaExcecoes.Add("sadistat");
			listaExcecoes.Add("Todos os Usuários");
			listaExcecoes.Add("Usuário Padrão");
			
			
		}
		
		
		void escreveLog(String informacoes)
		{
			Debug.WriteLine(informacoes);
			if(this.txtBoxLog.Text.Length == 0){
				this.txtBoxLog.Text =  informacoes;
			}else{
				this.txtBoxLog.Text = this.txtBoxLog.Text + Environment.NewLine + informacoes;
			}
			
			
		}
		
		void listarPerfis(){
			
			foreach(PerfilMicro perfil in listaPerfis){
				Debug.WriteLine("perfil: " + perfil.NomePerfil);
				Debug.WriteLine("pasta: " + perfil.FolderPath);
				Debug.WriteLine(String.Format("registro: {0}", perfil.Registry));
				Debug.WriteLine("selecionado: " + perfil.IsChecked);
			}
			
		}
		
		
		public void DeleteRegistry(PerfilMicro perfil){
			
			escreveLog("Removendo registro do perfil: " + perfil.NomePerfil);
			
			if(perfil.Registry != null){
				escreveLog("Tem registros do windows, tentando deletar");
				try {
					Debug.WriteLine(perfil.Registry);
					RegistryKey chave =  Registry.LocalMachine.OpenSubKey(PROFILE_LIST,true);
					chave.DeleteSubKey(perfil.Registry);
					escreveLog("Removeu registro do windows");
				} catch (Exception e) {
					escreveLog("Erro ao excluir registro do windows da chave: " + perfil.NomePerfil);
					escreveLog(e.Message);
				}
			}
			
			
			
		}
		
		
		
		
		
		public void DeleteDirectory(string target_dir)
		{
			
			try {
				
				string[] files = Directory.GetFiles(target_dir);
				escreveLog("pegou arquivos");
				string[] dirs = Directory.GetDirectories(target_dir);
				escreveLog("Pegou pastas");
				
				//aplica permissão normal para qualquer arquivo dentro da pasta em questão
				foreach (string file in files)
				{
					escreveLog("arquivo: " + file);
					//File.SetAttributes(file, FileAttributes.Normal);
					File.Delete(file);
					escreveLog("apagou arquivo: " + file);
				}
				
				foreach (string dir in dirs)
				{
					//remove permissão de somente leitura da pasta em questão
					escreveLog("Diretorio: " + dir);
					var diretorio = new DirectoryInfo(dir);
					diretorio.Attributes = diretorio.Attributes & ~FileAttributes.ReadOnly;
					escreveLog("aplicou permissão");
					DeleteDirectory(dir);
				}
				
				
				
				
				Directory.Delete(target_dir, true);
				
				escreveLog("Deletou tudo dentro do diretório " + target_dir);
				if(Directory.Exists(target_dir)){
					Directory.Delete(target_dir, true);
					escreveLog("Apagou diretorio raiz");
				}
				
			} catch (UnauthorizedAccessException uae) {
				escreveLog("Não tem acesso ao diretorio");
				escreveLog(uae.Message);
				
			}
			
			catch(Exception e){
				escreveLog("Erro não conhecido !!");
				escreveLog(e.Message);
			}
		}
		
		
		
		
		
		
		
		
		public void removerPerfil(PerfilMicro perfil){
			escreveLog("Removendo perfil: " + perfil.NomePerfil);
			
			
			if(perfil.Registry != null){
				escreveLog("Tem registros do windows, tentando deletar");
				DeleteRegistry(perfil);
			}
			
			escreveLog("Perfil "+ perfil.NomePerfil + " removido com sucesso..." );
			
		}
		
		
		
		
		
		
		void CheckedListBoxPerfisMicroSelectedIndexChanged(object sender, EventArgs e)
		{
			
			

			
		}
		
		
		void BtnMarcarTodosClick(object sender, EventArgs e){
			
			for (int i = 0; i < this.checkedListBoxPerfisMicro.Items.Count; i++) {
				PerfilMicro obj = (PerfilMicro)checkedListBoxPerfisMicro.Items[i];
				checkedListBoxPerfisMicro.SetItemChecked(i, true);
			}
			
		}
		
		void BtnDesmarcarTodosClick(object sender, EventArgs e)
		{
			for (int i = 0; i < this.checkedListBoxPerfisMicro.Items.Count; i++) {
				PerfilMicro obj = (PerfilMicro)checkedListBoxPerfisMicro.Items[i];
				checkedListBoxPerfisMicro.SetItemChecked(i, false);
			}
		}
		
		void BtnRemoverPerfisClick(object sender, EventArgs e){
			
			escreveLog("Perfis marcados para serem removidos");

			int qtdPerfisRemover = this.checkedListBoxPerfisMicro.CheckedItems.Count;
			int indicePerfilRemover = 1;
			escreveLog(qtdPerfisRemover + " perfis marcados para remoção...");
			
			foreach(PerfilMicro perfil in this.checkedListBoxPerfisMicro.CheckedItems){
				escreveLog(String.Format("\n Removendo perfil {0} de {1}", indicePerfilRemover,qtdPerfisRemover));
				this.removerPerfil(perfil);
				
				indicePerfilRemover++;
			}
			
			if(File.Exists(Environment.CurrentDirectory +"/removedor_perfil_SA_SD2.bat")){
				File.Delete(Environment.CurrentDirectory +"/removedor_perfil_SA_SD2.bat");
			}
			
			using(Stream arquivo = File.Open(Environment.CurrentDirectory +"/removedor_perfil_SA_SD2.bat", FileMode.OpenOrCreate))
				using(StreamWriter sw = new StreamWriter(arquivo)){
				sw.WriteLine("TITLE = NAO FECHE ESTA JANELA");
				sw.WriteLine("@echo off");
				sw.WriteLine("echo INICIANDO REMOCAO DAS PASTAS DE PERFIS ");
				sw.WriteLine("echo Quantidade de perfis para remover: " + qtdPerfisRemover);
				
				foreach(PerfilMicro perfil in this.checkedListBoxPerfisMicro.CheckedItems){
					if(!String.IsNullOrEmpty(perfil.FolderPath)){
						sw.WriteLine("echo Removendo perfil " + perfil.FolderPath);
						sw.WriteLine("rd /S /Q "+ perfil.FolderPath);
						sw.WriteLine("echo Perfil removido com sucesso: " + perfil.FolderPath);
					}
				}
				sw.WriteLine("echo Remocao de pastas concluida");
				sw.WriteLine("pause");
			}
			
			Process.Start(Environment.CurrentDirectory + "/removedor_perfil_SA_SD2.bat");
			
		

			
		}
		void Label3Click(object sender, EventArgs e)
		{
	
		}
		
		
		
		
	}
}