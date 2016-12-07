namespace MessageCoordinator.DTO
{
	public class ReadRecordsCountMessage:BusinnessLogicMessage {
		public string SchemaName { get; set; }
	}
	public class ReadRecordsCountResultMessage:BusinnessLogicMessage {
		public int Count { get; set; }
	}
}
