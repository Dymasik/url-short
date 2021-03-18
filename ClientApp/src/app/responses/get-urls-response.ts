import { Url } from "../url";

export class GetUrlsResponse {
    public Success: boolean;
    public ErrorMessage: string;
    public Urls: Url[]; 
}