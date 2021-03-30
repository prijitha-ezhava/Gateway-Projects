import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComponent } from './add.component';

describe('AddComponent', () => {
  let component: AddComponent;
  let fixture: ComponentFixture<AddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });

  //Positive Test Cases
  it('should perform correct addition',()=>{
    //Arrange
    const fixture = TestBed.createComponent(AddComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.add(120,30)).toEqual(150);
  });

  it('should return 0',()=>{
    //Arrange
    const fixture = TestBed.createComponent(AddComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.add(0,0)).toEqual(0);
  });

  //Negative Test Case
  it('should perform Incorrect addition',()=>{
    //Arrange
    const fixture = TestBed.createComponent(AddComponent);
    //Act
    const app = fixture.componentInstance;
    //Assert
    expect(app.add(120,30)).not.toEqual(100);
  });

});
