using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Models;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Interfaces;
using Tmuzik.Core.Interfaces.Services;

namespace Tmuzik.Core.Services
{
    public class ArtistService : AppService, IArtistService
    {
        private readonly IStorageHandler _storageHandler;

        public ArtistService(IServiceProvider serviceProvider, IStorageHandler storageHandler)
            : base(serviceProvider)
        {
            _storageHandler = storageHandler;
        }

        public async Task<ArtistInfo> ClaimArtistAsync(ClaimArtistRequest input, CancellationToken cancellationToken = default)
        {
            var userProfileId = CurrentUser.ProfileId.Value;

            var artist = new Artist
            {
                Name = input.Name,
                Description = input.Description,
                FacebookUrl = input.FacebookUrl,
                InstagramUrl = input.InstagramUrl,
                TwitterUrl = input.TwitterUrl,
                YoutubeUrl = input.YoutubeUrl,
                CreatorId = userProfileId,
            };

            if (input.Avatar != null)
            {
                var avatarUrl = await _storageHandler.SaveFileAsync(input.Avatar);
                artist.Avatar = avatarUrl;
            }
            if (input.Cover != null)
            {
                var coverUrl = await _storageHandler.SaveFileAsync(input.Cover);
                artist.Cover = coverUrl;
            }
            var photosSavingTasks = input.Photos.Select(url => _storageHandler.SaveFileAsync(url));
            var photoUrls = await Task.WhenAll(photosSavingTasks);
            artist.Photo.Items = photoUrls;

            // Save change to DB
            artist = await UnitOfWork.Artists.AddAsync(artist);

            // Mark user's profile as artist
            var userProfile = await UnitOfWork.UserProfiles.GetByIdAsync(userProfileId);
            userProfile.IsArtist = true;
            await UnitOfWork.UserProfiles.UpdateAsync(userProfile);

            var result = Mapper.Map<ArtistInfo>(artist);
            return result;
        }
    }
}