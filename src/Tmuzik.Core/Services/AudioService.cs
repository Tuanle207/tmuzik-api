using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Requests;
using Tmuzik.Core.Contract.Responses;
using Tmuzik.Core.Entities;
using Tmuzik.Core.Interfaces;
using Tmuzik.Core.Interfaces.Services;
using Tmuzik.Core.Specifications.Audios;

namespace Tmuzik.Core.Services
{
    public class AudioService : AppService, IAudioService
    {
        private readonly IStorageHandler _storageHandler;

        public AudioService(IServiceProvider serviceProvider, IStorageHandler storageHandler)
            : base(serviceProvider)
        {
            _storageHandler = storageHandler;
        }

        public async Task<UploadAudioResponse> AddAudioAsync(UploadAudioRequest input, CancellationToken cancellationToken = default)
        {
            var audio = Mapper.Map<Audio>(input);
            audio.CreatorId = CurrentUser.ProfileId.Value;

            if (input.CoverFile != null)
            {
                var coverUrl = await _storageHandler.SaveFileAsync(input.CoverFile);
                audio.Cover = coverUrl;
            }

            var audioUrl = await _storageHandler.SaveFileAsync(input.AudioFile);
            audio.File = audioUrl;

            audio = await UnitOfWork.Audios.AddAsync(audio, cancellationToken);

            var result = Mapper.Map<UploadAudioResponse>(audio);
            return result;
        }

        public async Task<GetUserUploadAudioResponse> GetUserUploadAudioAsync(GetUserUploadAudioRequest input, CancellationToken cancellationToken = default)
        {
            var userId = CurrentUser.ProfileId.Value;
            var querySpec = new AudioWithPaginationSpecification(input, userId);
            var selector = UnitOfWork.Audios.CreateSelector(x => Mapper.Map<UserUploadAudio>(x));
            
            var items = await UnitOfWork.Audios.ListAsync(querySpec, selector, cancellationToken);
            var totalCount = await UnitOfWork.Audios.CountAllAsync(cancellationToken);

            var result = new GetUserUploadAudioResponse
            {
                Items = items,
                PageIndex = input.PageIndex ?? 1,
                PageSize = items.Count,
                TotalCount = totalCount
            };

            return result;
        }
    }
}