import { fakeAsync, TestBed, tick } from '@angular/core/testing';

import { HttpService } from './http.service';

describe('HttpService', () => {
  let service: HttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpService);
  });

  // it('should be created', () => {
  //   expect(service).toBeTruthy();
  // });

  //Returns length using async [POSITIVE TEST CASE]
  it('should return the length of the user data using async', async()=>{
    //Act
    const result = await service.getAllUsers();
    //Assert
    expect(result.length).toBe(4);
  });

  //Returns length using done  [POSITIVE TEST CASE]
  it('should return the length of the user data using done',(done)=>{
    const result =  service.getAllUsers().then(data=>{
      expect(data.length).toBe(4);
    });
    done();
  });

  //Returns length using fakeasync  [POSITIVE TEST CASE]
  it('should return the length of the user data using fakeasync',fakeAsync(()=>{
    tick();
    expect(service.getAllUsers).toBeTruthy();
    const result =  service.getAllUsers().then(data=>{
      expect(data.length).toBe(4);
    });
  }));

  //Returns length using async  [NEGATIVE TEST CASE]
  it('should return the length of the user data using async', async()=>{
    //Act
    const result = await service.getAllUsers();
    //Assert
    expect(result.length).not.toBe(3);
  });

  //Returns length using done  [NEGATIVE TEST CASE]
  it('should return the length of the user data using done',(done)=>{
    const result =  service.getAllUsers().then(data=>{
      expect(data.length).not.toBe(7);
    });
    done();
  });

});
