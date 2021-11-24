using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsAndCellsDTO
    {
        [Required, MinLength(3), MaxLength(25)]
        public string Name { get; set; }

        public IEnumerable<CellsDTO> Cells { get; set; }
    }
}
