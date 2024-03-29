﻿namespace Shared.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace Shared.Models
    {

        public class ResponseViewModel
        {

            public int Id { get; set; }
            [Required(ErrorMessage = "Please write your response!")]
            [MinLength(1, ErrorMessage = "Response to short!")]
            public string Response { get; set; } = null!;
            public string SubmittedBy { get; set; } = null!;
            public int TicketId { get; set; }
            public TicketModel Ticket { get; set; } = null!;

        }

        public class TicketTagViewModel
        {
            public int TicketId { get; set; }
            public TicketModel Ticket { get; set; }
            public int TagId { get; set; }
            public TagModel Tag { get; set; }

        }

        public class TagViewModel
        {

            public int Id { get; set; }
            public string Name { get; set; } = null!;

            public static TagViewModel TagViewModelFromApiModel(TagModelAPIModel apiModel)
            {
                return new TagViewModel
                {
                    Id = apiModel.Id,
                    Name = apiModel.Name,
                };
            }
        }

        public class TicketViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; } = null!;

            public string? Description { get; set; }
            public string SubmittedBy { get; set; } = null!;
            public bool IsResolved { get; set; }
            public string? Image { get; set; }

            public List<ResponseModel> Responses { get; set; } = new();

            /* 
            En statisk metod passar bäst när den inte är beroende av någon specifik instans av sin klass
            för att utföra sin uppgift. Det innebär att metoden inte behöver någon information från
            instansvariabler eller andra instansspecifika egenskaper för att fungera korrekt.
            */

            //------- Metoder som konverterar API-modeller till motsvarande viewmodel. --------------
            public static TicketViewModel TicketViewModelFromApiModel(TicketModel apiModel)
            {
                return new TicketViewModel
                {
                    Id = apiModel.Id,
                    Title = apiModel.Title,
                    Description = apiModel.Description ?? string.Empty,
                    SubmittedBy = apiModel.SubmittedBy,
                    IsResolved = apiModel.IsResolved

                };
            }






        }

    }

}
