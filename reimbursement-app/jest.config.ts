export default {
    preset: 'jest-preset-angular',
    setupFilesAfterEnv: ['<rootDir>/src/app/setup-jest.ts'],
    testMatch: ['<rootDir>/src/app/**/*.spec.ts'],
    transform: {
      '^.+\\.(ts|html)$': 'ts-jest',
    },
    collectCoverage: true,
    coverageReporters: ['html', 'lcov'],
  };
  