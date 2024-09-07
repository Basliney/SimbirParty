using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ScoreClient
{
    private const string _HOST = "https://score.mrexpen.duckdns.org:444";

    /// <summary>
    /// Отправить данные о счёте.
    /// </summary>
    /// <param name="score">Информация о счёте.</param>
    /// <returns>Счет.</returns>
    public async Task<ScoreEntity> SendScoreAsync(ScoreEntity score)
    {
        using (var client = new HttpClient())
        {
            var json = JsonConvert.SerializeObject(score);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_HOST}/Scores", content);

            return JsonConvert.DeserializeObject<ScoreEntity>(json);
        }
    }

    /// <summary>
    /// Получает список своих счетов по идентификатору пользователя.
    /// </summary>
    /// <param name="playerId">Идентификатор игрока.</param>
    /// <returns>Список счетов пользователя.</returns>
    public async Task<List<ScoreEntity>> GetScoresByPlayerIdAsync(Guid playerId)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{_HOST}/Players/{playerId}/Scores");
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ScoreEntity>>(json);
        }
    }

    /// <summary>
    /// Получает список всех счетов.
    /// </summary>
    /// <param name="page">Номер страницы.</param>
    /// <param name="pageSize">Размер страницы.</param>
    /// <returns>Список счетов.</returns>
    public async Task<List<ScoreEntity>> GetScoresAsync(int page, int pageSize)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{_HOST}/Scores?page={page}&pageSize={pageSize}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<ScoreEntity>>(json);
        }
    }
    /// <summary>
    /// Получает информацию об счёте по его идентификатору.
    /// </summary>
    /// <param name="scoreId">Идентификатор счёта.</param>
    /// <returns>Счет.</returns>
    public async Task<ScoreEntity> GetScoresByIdAsync(int scoreId)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync($"{_HOST}/Scores/{scoreId}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ScoreEntity>(json);
        }
    }
}