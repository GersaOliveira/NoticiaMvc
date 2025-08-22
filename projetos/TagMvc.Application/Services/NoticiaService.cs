using TagMvc.Application.Interfaces;
using TagMvc.Domain.Entities;
using TagMvc.Domain.Interfaces;
using System;

namespace TagMvc.Application.Services;

public class NoticiaService : INoticiaService
{
    private readonly INoticiaRepository _noticiaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITagRepository _tagRepository;

    public NoticiaService(INoticiaRepository noticiaRepository, IUnitOfWork unitOfWork, ITagRepository tagRepository)
    {
        _noticiaRepository = noticiaRepository;
        _unitOfWork = unitOfWork;
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<Noticia>> GetAllAsync()
    {
        return await _noticiaRepository.GetAllAsync();
    }

    public async Task<Noticia?> GetByIdAsync(int id)
    {
        return await _noticiaRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Noticia noticia, string tagsCsv)
    {
        if (!string.IsNullOrWhiteSpace(tagsCsv))
        {
            var tagDesc = tagsCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var nome in tagDesc)
            {
                var descTagLimpo = nome.Trim();
                if (string.IsNullOrEmpty(descTagLimpo)) continue;

                var tagExistente = await _tagRepository.GetByDescAsync(descTagLimpo);

                if (tagExistente == null)
                {
                    tagExistente = new Tag { Descricao = descTagLimpo };
                }

                noticia.NoticiaTags.Add(new NoticiaTag { Tag = tagExistente });
            }
        }

        await _noticiaRepository.AddAsync(noticia);
        await _unitOfWork.CommitAsync();
    }

    public async Task UpdateAsync(Noticia noticia, string tagsCsv)
    {
        var noticiaToUpdate = await _noticiaRepository.GetByIdAsync(noticia.Id);
        if (noticiaToUpdate == null)
        {
            return; 
        }

        noticiaToUpdate.Titulo = noticia.Titulo;
        noticiaToUpdate.Texto = noticia.Texto;

        noticiaToUpdate.NoticiaTags.Clear();
        await ProcessTags(noticiaToUpdate, tagsCsv);

        await _noticiaRepository.Update(noticia);
        await _unitOfWork.CommitAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var noticia = await _noticiaRepository.GetByIdAsync(id);
        if (noticia != null)
        {
            await _noticiaRepository.Remove(noticia);
            await _unitOfWork.CommitAsync();
        }
    }
    
    private async Task ProcessTags(Noticia noticia, string tagsCsv)
        {
            if (string.IsNullOrWhiteSpace(tagsCsv)) return;

            var tagNomes = tagsCsv.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(nome => nome.Trim().ToLower())
                                  .Distinct();

            foreach (var nomeTag in tagNomes)
            {
                if (string.IsNullOrEmpty(nomeTag)) continue;

                var tagExistente = await _tagRepository.GetByDescAsync(nomeTag);
                if (tagExistente == null)
                {
                    tagExistente = new Tag { Descricao = nomeTag };
                }
                noticia.NoticiaTags.Add(new NoticiaTag { Tag = tagExistente });
            }
        }
}

