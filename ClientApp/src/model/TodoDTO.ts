export class TodoDTO {
  constructor(
    public ID?: number,
    public Name?: string,
    public Description?: string,
    public IsCompleted?: boolean,
    public UserId?: number
  ) {}
}
