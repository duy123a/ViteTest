import { defineConfig } from 'vite'
import path from 'path'

export default defineConfig({
    appType: 'custom',
    root: path.resolve(__dirname, 'Assets'),
    build: {
        manifest: true,
        outDir: path.resolve(__dirname, 'dist'),
        emptyOutDir: true,
        assetsDir: '',
        rollupOptions: {
            input: {
                main: path.resolve(__dirname, 'Assets/main.js'),
            },
            output: {
                entryFileNames: '[name].js',
                chunkFileNames: '[name].js',
                assetFileNames: '[name].[ext]',
            }
        }
    },
    server: {
        port: 5173,
        strictPort: true,
        hmr: {
            clientPort: 5173
        }
    }
})
