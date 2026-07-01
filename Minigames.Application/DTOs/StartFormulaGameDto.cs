public record StartFormulaGameDto(
    string PlayerName,
    List<int> Numbers,
    int Target
    );

public record SubmitFormulaAnswerDto(
    string PlayerName,
    string Expression
    );

public record FormulaAnswerResultDto(
    int Result,
    int Difference,
    string Message
    );