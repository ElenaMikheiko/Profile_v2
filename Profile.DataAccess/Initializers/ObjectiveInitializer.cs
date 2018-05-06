using Profile.DataAccess.Data;
using Profile.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Profile.Web.Initializers
{
    public static class ObjectiveInitializer
    {
        public static void Initialize(ProfileDbContext context)
        {
            IList<Stream> streams = new List<Stream>
            {
                new Stream
                {
                    StreamFullName = "Android Developer",
                    StreamShortName = "AD"
                },
                new Stream
                {
                    StreamFullName = "Java Automated Testing",
                    StreamShortName = "AT"
                },
                new Stream
                {
                    StreamFullName = "Business Analyst",
                    StreamShortName = "BA"
                },
                new Stream
                {
                    StreamFullName = "C++ Developer",
                    StreamShortName = "CD"
                },
                new Stream
                {
                    StreamFullName = "Front-end",
                    StreamShortName = "FD"
                },
                new Stream
                {
                    StreamFullName = "Java Developer",
                    StreamShortName = "JD"
                },
                new Stream
                {
                    StreamFullName = "ASP.NET Developer",
                    StreamShortName = "ND"
                },
                new Stream
                {
                    StreamFullName = "iOS Developer",
                    StreamShortName = "ID"
                },
                new Stream
                {
                    StreamFullName = "PHP Developer",
                    StreamShortName = "PD"
                },
                new Stream
                {
                    StreamFullName = "Python Developer",
                    StreamShortName = "PT"
                },
                new Stream
                {
                    StreamFullName = "Python Automated Testing",
                    StreamShortName = "PT2"
                },
                new Stream
                {
                    StreamFullName = "Software Testing",
                    StreamShortName = "ST"
                },
                new Stream
                {
                    StreamFullName = "UI/UX Designer",
                    StreamShortName = "UI/UX"
                }
            };

            foreach (Stream str in streams)
            {
                var existingStream = context.Streams.FirstOrDefault(s => s.StreamShortName == str.StreamShortName);
                if (existingStream != null)
                {
                    existingStream.StreamFullName = str.StreamFullName;
                    existingStream.StreamShortName = str.StreamShortName;
                    context.Streams.Update(existingStream);
                }
                else
                {
                    context.Streams.Add(str);
                }
            }

            context.SaveChanges();
        }
    }
}
