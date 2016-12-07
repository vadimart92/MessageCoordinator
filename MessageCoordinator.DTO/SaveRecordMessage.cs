namespace MessageCoordinator.DTO {
	public class SaveRecordMessage : BusinnessLogicMessage
	{
		public Schema Guid { get; set; }
		public string SerializeedData { get; set; }
	}
}