using Chinook_Backend.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
	public class ChinookContext : DbContext
	{
		public DbSet<Album> Album { get; set; }
		public DbSet<Artist> Artist { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<Genre> Genre { get; set; }
		public DbSet<Invoice> Invoice { get; set; }
		public DbSet<InvoiceLine> InvoiceLine { get; set; }
		public DbSet<MediaType> MediaType { get; set; }
		public DbSet<Playlist> Playlist { get; set; }
		public DbSet<PlaylistTrack> PlaylistTrack { get; set; }
		public DbSet<Track> Track { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }



		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Chinook;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PlaylistTrack>()
				.HasKey(x => new { x.TrackId, x.PlaylistId });

			

		}
	}
}
