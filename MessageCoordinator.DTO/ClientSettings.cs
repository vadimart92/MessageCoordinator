namespace MessageCoordinator.DTO {
	public class ClientSettings {
		public DbSettings DbSettings { get; set; }
		public string RedisSettings { get; set; }
		public User User { get; set; }
	}
}