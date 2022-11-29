namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    public class TestAttendee : TestRecipient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestAttendee"/> class.
        /// </summary>
        public TestAttendee()
        {
            this.ODataType = "serviceNow.graph.attendee";
        }

    }
}
