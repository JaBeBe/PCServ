
import { TestBed, inject, async } from '@angular/core/testing';
import { HttpService } from '../login/http.service';
import { HttpTestingController, HttpClientTestingModule } from '@angular/common/http/testing';

describe('TestService', () => {

    let httpMock: HttpTestingController;
    let testService: HttpService;

    beforeEach(() => {

        TestBed.configureTestingModule({
            imports: [HttpClientTestingModule],
            providers: [HttpService]
        });

        testService = TestBed.get(HttpService);
        httpMock = TestBed.get(HttpTestingController);

    });

    it('getData() should http GET users',  async(() => {
        const user =
            [{
                "id": 4,
                "FirstName": "Mike",
                "LastName": "JSON",
                "EMail": "mike.json@gmail.com",
                "Login": "mike.json",
                "Password": "mike.json123"
            }];
        testService.getData().subscribe((res) => {
            expect(res).toEqual(user);
        });
    }));

    
});
