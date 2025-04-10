import 'jest-preset-angular/setup-jest';
// Mocking global objects or methods

  
  global.matchMedia = jest.fn().mockReturnValue({
    matches: false,
    addListener: jest.fn(),
    removeListener: jest.fn(),
  });