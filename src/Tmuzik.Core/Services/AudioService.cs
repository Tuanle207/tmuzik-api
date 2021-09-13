using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Tmuzik.Core.Contract.Models;
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

        public async Task<AudioItem> AddAudioAsync(UploadAudioRequest input, CancellationToken cancellationToken = default)
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

            await UnitOfWork.Audios.AddAsync(audio, cancellationToken);

            var audioSpec = new AudioIncludesFieldsSpecification(audio.Id);
            var audioSelector = UnitOfWork.Audios.CreateSelector(x => Mapper.Map<AudioItem>(x));
            var result = await UnitOfWork.Audios.FirstOrDefaultAsync(audioSpec, audioSelector);
            return result;
        }

        public async Task<GetUserUploadAudioResponse> GetUserUploadAudioAsync(GetUserUploadAudioRequest input, CancellationToken cancellationToken = default)
        {
            var userId = CurrentUser.ProfileId.Value;
            var querySpec = new AudioIncludesFieldsSpecification(input, userId);
            var selector = UnitOfWork.Audios.CreateSelector(x => Mapper.Map<AudioItem>(x));
            
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