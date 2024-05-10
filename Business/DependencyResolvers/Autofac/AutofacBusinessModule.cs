using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Castle.DynamicProxy;
using Module = Autofac.Module;
using Chinook_Backend.Utilities.Interceptors;
using Chinook_Backend.Utilities.Security.JWT;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AlbumManager>().As<IAlbumService>().SingleInstance();
			builder.RegisterType<EfAlbumDal>().As<IAlbumDal>().SingleInstance();

			builder.RegisterType<ArtistManager>().As<IArtistService>().SingleInstance();
			builder.RegisterType<EfArtistDal>().As<IArtistDal>().SingleInstance();

			builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
			builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

			builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
			builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();

			builder.RegisterType<GenreManager>().As<IGenreService>().SingleInstance();
			builder.RegisterType<EfGenreDal>().As<IGenreDal>().SingleInstance();

			builder.RegisterType<InvoiceManager>().As<IInvoiceService>().SingleInstance();
			builder.RegisterType<EfInvoiceDal>().As<IInvoiceDal>().SingleInstance();

			builder.RegisterType<InvoiceLineManager>().As<IInvoiceLineService>().SingleInstance();
			builder.RegisterType<EfInvoiceDal>().As<IInvoiceDal>().SingleInstance();

			builder.RegisterType<MediaTypeManager>().As<IMediaTypeService>().SingleInstance();
			builder.RegisterType<EfMediaTypeDal>().As<IMediaTypeDal>().SingleInstance();

			builder.RegisterType<PlaylistManager>().As<IPlaylistService>().SingleInstance();
			builder.RegisterType<EfPlaylistDal>().As<IPlaylistDal>().SingleInstance();

			builder.RegisterType<PlaylistTrackManager>().As<IPlaylistTrackService>().SingleInstance();
			builder.RegisterType<EfPlaylistTrackDal>().As<IPlaylistTrackDal>().SingleInstance();

			builder.RegisterType<TrackManager>().As<ITrackService>().SingleInstance();
			builder.RegisterType<EfTrackDal>().As<ITrackDal>().SingleInstance();

			builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
			builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

			builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

			builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();


			var assembly = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
				.EnableInterfaceInterceptors(new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).SingleInstance();

		}
	}
}
