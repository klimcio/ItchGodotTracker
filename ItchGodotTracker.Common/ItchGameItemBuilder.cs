using System.Globalization;

namespace ItchGodotTracker.Common
{
    internal class ItchGameItemBuilder
    {
        public ItchGame Create(ItchGameMediatorClass mediator)
        {
            return new ItchGame(
                url: ParseUrl(mediator.Url),
                authors: ParseAuthors(mediator.Author, mediator.Authors),
                uploader: mediator.Uploader ?? string.Empty,
                tags: ParseArray(mediator.Tags),
                inputs: ParseArray(mediator.Inputs),
                published: ParseDate(mediator.Published),
                languages: ParseArray(mediator.Languages),
                status: mediator.Status ?? string.Empty,
                platforms: ParseArray(mediator.Platforms),
                genre: mediator.Genre ?? string.Empty,
                madeWith: mediator.MadeWith ?? string.Empty,
                averageSession: mediator.AverageSession ?? string.Empty,
                releaseDate: ParseDate(mediator.ReleaseDate),
                updated: ParseDate(mediator.Updated),
                accessibility: ParseArray(mediator.Accessibility),
                links: ParseArray(mediator.Links),
                mentions: ParseArray(mediator.Mentions)
            );
        }

        private DateTime? ParseDate(string? dateTimeString)
        {
            if (dateTimeString == null)
                return null;

            var dateParts = dateTimeString.Split(' ');

            var day = Convert.ToInt32(dateParts[2]);
            var year = Convert.ToInt32(dateParts[3]);
            var month = DateTimeFormatInfo.InvariantInfo
                .AbbreviatedMonthNames
                .ToList()
                .IndexOf(dateParts[1]) + 1;

            return new DateTime(year, month, day);
        }

        private string[] ParseArray(string? tags)
        {
            if (tags == null)
                return Array.Empty<string>();

            return tags
                .Split(',')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToArray();
        }

        private Uri? ParseUrl(string? url) => url == null ? null : new Uri(url);

        private string[] ParseAuthors(string? author, string? authors)
        {
            var authorsList = new List<string>();

            if (author != null)
            {
                authorsList.Add(author);
            }

            if (authors != null)
            {
                authorsList.AddRange(authors.Split(','));
            }

            return authorsList
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x => x.Trim())
                .ToArray();
        }
    }
}