/*
 * Criado por SharpDevelop.
 * Usuário: V7BA
 * Data: 09/07/2015
 * Hora: 08:18
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using Microsoft.Win32;

namespace RemovedorPerfil
{
	/// <summary>
	/// Description of PerfilMicro.
	/// </summary>
	public class PerfilMicro
	{
		public bool IsChecked{get; set; }
		public string NomePerfil {get; set; } 
		public string FolderPath {get; set; }
		public string Registry {get; set; }
		
		public PerfilMicro(String nomePerfil)
		{
			this.NomePerfil = nomePerfil;
		}
	
		public override bool Equals(Object obj)
		{
			// Check for null values and compare run-time types.
			if (obj == null || GetType() != obj.GetType())
				return false;

			return string.Compare(((PerfilMicro)obj).NomePerfil, this.NomePerfil, StringComparison.Ordinal) == 0;
			
		}
		
		public override int GetHashCode()
		{
			return this.NomePerfil.GetHashCode();
		}
		
	
	}
}
