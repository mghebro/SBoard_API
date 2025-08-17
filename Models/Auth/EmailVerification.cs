using ORA_API.Common.Entities;

namespace ORA_API.Models.Auth;

// არსებობს მეორე პრაცტიკა სადაც verification-კლასი გაქსვ და enum-ებით ანსხვავებ მაგრამ ამ ჯერზე ეს იყოს.
// უმჯობესი იქნება ასეთი სტრუქტურით თუ გაკეთდება ვერიფიკაციები - თუ არ გინდათ მაშინ დატოვეთ ძველი მაგრამ ძველი ცუდი პრაკტიკაითაა დაწერილი
public class EmailVerification : BaseEntity
{
    public string Token { get; set; } = Guid.NewGuid().ToString();

    public string Code { get; set; }

    public DateTime ExpiresAt { get; set; } = DateTime.Today.AddMinutes(15);

    public bool IsVerified { get; set; } = false;

    public DateTime? VerifiedAt { get; set; }

    public int AttemptCount { get; set; } = 0;

    // Relations   
    public int UserId { get; set; }
    public User User { get; set; }
}